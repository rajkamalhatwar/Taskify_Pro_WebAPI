using ProjectAPI.Entity;
using ProjectAPI.Interfaces;
using ProjectAPI.Repository;
using ProjectAPI.ServiceInterfaces;
using ProjectAPI.ViewModel;

namespace ProjectAPI.Services
{
    public class UserRegService : IUserReg
    {
        private readonly IUserRegService _IUserRegService;
        public UserRegService(IUserRegService iUserRegService)
        {
            _IUserRegService = iUserRegService;
        }
        public async Task<long> SaveUser(VMUserReg vMUserReg)
        {
            UserRegEntity userRegEntity = new UserRegEntity
            {
                UserId = vMUserReg.UserId,
                FullName = vMUserReg.FullName,
                Email = vMUserReg.Email,
                Password = vMUserReg.Password,
                MobileNumber = vMUserReg.MobileNumber,
                Gender = vMUserReg.Gender,
                IsActive = vMUserReg.IsActive
            };

            // Call the repository method
            long result = await _IUserRegService.SaveUser(userRegEntity);

            return result;
        }
    }
}
