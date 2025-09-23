using ProjectAPI.Entity;
using ProjectAPI.ViewModel;

namespace ProjectAPI.Interfaces
{
    public interface ITask
    {
        Task<TaskDropdownEntity> GetTaskDropdowns(int userId);
    }
}
