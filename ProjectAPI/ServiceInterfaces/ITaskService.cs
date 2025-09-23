using ProjectAPI.Entity;
using ProjectAPI.ViewModel;

namespace ProjectAPI.ServiceInterfaces
{
    public interface ITaskService
    {
        Task<VMTaskDropdown> GetTaskDropdowns(int userId);
    }
}
