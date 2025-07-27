using AutoMapper;
using ProjectAPI.Entity;
using ProjectAPI.Repository;
using ProjectAPI.ServiceInterfaces;
using ProjectAPI.ViewModel;

namespace ProjectAPI.Services
{
    public class UserService : IUser
    {
        private readonly IUserService _IUserService;
       

        public UserService(IUserService iUserService )
        {
            _IUserService = iUserService;
            
        }
        public async Task<VMUser> GetAllUsers()
        {
            UserEntity userEntity = await _IUserService.GetAllUsers();
            
             
            VMUser vmUser = new VMUser
            {
                Users = userEntity.Users.Select(u => new VMUserDetail
                {
                    UserName = u.UserName,
                    UserRoll = u.UserRoll
                }).ToList()
            };

            return vmUser;
        }

        
    }
}
