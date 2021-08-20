using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserProfilePictureDal:EfEntityRepositoryBase<UserProfilePicture,RentACarContext>,IUserProfilePictureDal
    {
        
    }
}