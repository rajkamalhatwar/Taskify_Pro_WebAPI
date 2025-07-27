using ProjectAPI.Entity;
using ProjectAPI.ServiceInterfaces;
using ProjectAPI.ServiceInterfaces;
using System.Data;

namespace ProjectAPI.Repository
{
    public class UserRepo : IUserService
    {
        public async Task<UserEntity> GetAllUsers()
        {


            UserEntity UserEntity = new UserEntity();
            try
            {

                UserEntity.Users = new List<UserDetail>
                {
                    new UserDetail { UserRoll = 1, UserName = "Rajkamal" },
                    new UserDetail { UserRoll = 2, UserName = "Anjan" }
                }; 

                UserEntity.Users = new List<UserDetail>
                {
                    new UserDetail { UserRoll = 1, UserName = "Rohan" },
                    new UserDetail { UserRoll = 2, UserName = "Raj" }
                };
            }
            catch (Exception ex)
            {

                 
            }
            return UserEntity;
        }
    }
}
