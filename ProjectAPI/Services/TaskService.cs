using ProjectAPI.Interfaces;
using ProjectAPI.ServiceInterfaces;
using ProjectAPI.ViewModel;

namespace ProjectAPI.Services
{
    public class TaskService : ITaskService
    {
        readonly ITask _ITask;
        public TaskService(ITask task)
        {
            _ITask = task;
        }

        public async Task<VMTaskDropdown> GetTaskDropdowns(int userId)
        {
            var taskDropdowns = await _ITask.GetTaskDropdowns(userId); // Assuming this returns TaskDropdownEntity

            var vmTaskDropdown = new VMTaskDropdown
            {
                GetWorkspacesDropdown = taskDropdowns.GetWorkspacesDropdown?
                    .Select(ws => new VMWorkspace
                    {
                        Id = ws.Id,
                        WorkSpaceName = ws.WorkSpaceName
                    }).ToList()
            };

            return vmTaskDropdown;

        }
    }
}
