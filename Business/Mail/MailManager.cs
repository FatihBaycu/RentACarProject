using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Business.Abstract;
using Business.ValidationRules.FluentValidations;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Mail
{
    public class MailManager : IMailService
    {
        readonly IConfiguration _configuration;
        private readonly IResetPasswordCodeService _resetPasswordCodeService;
        private readonly IUserService _userService;

        public MailManager(IConfiguration configuration, IResetPasswordCodeService resetPasswordCodeService, IUserService userService)
        {
            _configuration = configuration;
            _resetPasswordCodeService = resetPasswordCodeService;
            _userService = userService;
        }

        public IResult SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            SendMailAsync(new[] { to }, subject, body, isBodyHtml);
            return new SuccessResult("Mail Gönderildi.");

        }

        public IResult SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = isBodyHtml;
            foreach (var to in tos)
                mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new MailAddress(_configuration["Mail:Username"], "RentACar", System.Text.Encoding.UTF8);


            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = _configuration["Mail:Host"];
            smtp.SendMailAsync(mail);
            return new SuccessResult("Mail Gönderildi.");

        }

        [ValidationAspect(typeof(EmailValidator))]
        public IResult SendPasswordResetMailAsync(Email to)
        {
            string code = Guid.NewGuid().ToString();

            User user = new User();
            user = _userService.GetUserByEmail(to.EmailAddress.ToString()).Data;

            if (user == null) { return new ErrorResult("Kullanıcı Bulunamadı!"); }

            ResetPasswordCode resetPasswordCode = new ResetPasswordCode
            {
                Code = code,
                IsActive = true,
                UserEmail = to.EmailAddress,
                CreatedAt = DateTime.Now,
                EndDate = DateTime.Now.AddHours(3),
                UserId = user.Id
            };

            _resetPasswordCodeService.Add(resetPasswordCode);

            StringBuilder mail = new StringBuilder();
            mail.AppendLine("Merhaba<br>Eğer yeni şifre talebinde bulunduysanız aşağıdaki linkten şifrenizi yenileyebilirsiniz.<br><strong><a target=\"_blank\" href=\"");
            mail.AppendLine(_configuration["AngularClientUrl"]);
            mail.AppendLine("/update-password");
            mail.AppendLine("?userId="+user.Id.ToString());
            mail.AppendLine("&code="+code);
            mail.AppendLine("\">Yeni şifre talebi için tıklayınız...</a></strong><br><br><span style=\"font-size:12px;\">NOT : Eğer ki bu talep tarafınızca gerçekleştirilmemişse lütfen bu maili ciddiye almayınız.</span><br>Saygılarımızla...<br><br><br>NG - Mini|E-Ticaret");

            SendMailAsync(to.EmailAddress, "Şifre Yenileme Talebi", mail.ToString());
            return new SuccessResult("Mail Gönderildi.");

        }
    }
}
