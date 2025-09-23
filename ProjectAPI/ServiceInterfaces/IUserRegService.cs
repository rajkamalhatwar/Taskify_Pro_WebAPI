using ProjectAPI.Entity;

namespace ProjectAPI.ServiceInterfaces
{
    public interface IUserRegService
    {
        Task<long> SaveUser(UserRegEntity userRegEntity);
    }
}
