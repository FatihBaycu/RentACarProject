using Core.Entities;

namespace Entities.Concrete
{
    public class UserProfilePicture : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PicturePath { get; set; }
    }
}