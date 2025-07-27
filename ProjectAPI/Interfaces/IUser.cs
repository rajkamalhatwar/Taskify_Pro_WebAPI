using ProjectAPI.ViewModel;

namespace ProjectAPI.Repository
{
    public interface IUser
    {
        Task<VMUser> GetAllUsers();
    }
}
