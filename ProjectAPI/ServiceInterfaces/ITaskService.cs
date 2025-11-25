using ProjectAPI.Entity;
using ProjectAPI.ViewModel;

namespace ProjectAPI.ServiceInterfaces
{
    public interface ITaskService
    {
        Task<VMTaskDropdown> GetTaskDropdowns(int userId);
        Task<VMTaskUserDetail> GetUserDetailById(int userId);
        Task<long> SaveTask(VMTask vMTask);
        Task<VMTaskDetailByUser> GetTaskDetailByUser(int userId);
        Task<VMTaskDetailById> GetTaskDetailById(int taskId);
        Task<long> UpdateTaskStatus(VMUpdateTaskStatus vMUpdateTaskStatus);
    }
}
