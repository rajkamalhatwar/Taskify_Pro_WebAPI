using ProjectAPI.Entity;

namespace ProjectAPI.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserEntity> GetAllUsers();
    }
}
