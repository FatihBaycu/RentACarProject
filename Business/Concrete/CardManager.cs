using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Design;

namespace Business.Concrete
{
   public class CardManager:ICardService
   {
       private ICardDal _iCardDal;

       public CardManager(ICardDal iCardDal)
       {
           _iCardDal = iCardDal;
       }


       public IResult Add(Card card)
       {
            var result = _iCardDal.Get(p => p.CardNumber == card.CardNumber&&p.CustomerId==card.CustomerId);

            if (result != null)
            {
                if (result.CardNumber == card.CardNumber) return new SuccessResult();
            }

            _iCardDal.Add(card);
           return new SuccessResult("Kart Bilgileri Eklendi");
       }

       public IResult Update(Card card)
       {
            _iCardDal.Update(card);
            return new SuccessResult("Kart Bilgileri Güncellendi");

        }

        public IResult Delete(Card card)
       {
           _iCardDal.Update(card);
           return new SuccessResult("Kart Bilgileri Silindi");
        }

       public IDataResult<List<Card>> GetAll()
       {
           return new SuccessDataResult<List<Card>>(_iCardDal.GetAll(), true, Messages.Listed);

        }

        public IDataResult<Card> GetById(int cardId)
        {
           return new DataResult<Card>(_iCardDal.Get(p => p.id == cardId), true, Messages.Listed);
        }

        public IDataResult<List<Card>> GetCardByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Card>>(_iCardDal.GetAll(p => p.CustomerId == customerId), true,
                Messages.Listed);
        }
   }
}
