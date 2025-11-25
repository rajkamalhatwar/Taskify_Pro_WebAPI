using ProjectAPI.Entity;
using ProjectAPI.ViewModel;

namespace ProjectAPI.Interfaces
{
    public interface ITask
    {
        Task<TaskDropdownEntity> GetTaskDropdowns(int userId);
        Task<TaskUserDetailEntity> GetUserDetailById(int userId);
        Task<long> SaveTask(TaskEntity taskEntity);
        Task<TaskDetailByUserEntity> GetTaskDetailByUser(int userId);
        Task<TaskDetailByIdEntity> GetTaskDetailById(int taskId);
        Task<long> UpdateTaskStatus(TaskEntity taskEntity);
    }
}
