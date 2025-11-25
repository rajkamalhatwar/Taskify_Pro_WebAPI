using ProjectAPI.Entity;
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
            var taskDropdowns = await _ITask.GetTaskDropdowns(userId);  

            var vmTaskDropdown = new VMTaskDropdown
            {
                GetWorkspacesDropdown = taskDropdowns.GetWorkspacesDropdown?
                    .Select(ws => new VMWorkspace
                    {
                        Id = ws.Id,
                        WorkSpaceName = ws.WorkSpaceName
                    }).ToList(),

                GetUserDropdown = taskDropdowns.GetUserDropdown?
                    .Select(ws => new VMUsersList
                    {
                        Id = ws.Id,
                        UserName = ws.UserName
                    }).ToList()
            };

            return vmTaskDropdown;

        }

        public async Task<VMTaskUserDetail> GetUserDetailById(int userId)
        {
            var taskUserDetail = await _ITask.GetUserDetailById(userId);

            var vmTaskUserDetail = new VMTaskUserDetail
            {
                GetUserDetailById = taskUserDetail.GetUserDetailById?
                    .Select(ws => new VMUserDetailById
                    {
                        Id = ws.Id,
                        UserName = ws.UserName,
                        Email = ws.Email,
                        MobileNo = ws.MobileNo,
                        Gender = ws.Gender,
                        ActiveStatus = ws.ActiveStatus
                    }).ToList()
     
            };

            return vmTaskUserDetail;
        }

        public async Task<long> SaveTask(VMTask vMTask)
        {
            TaskEntity taskEntity = new TaskEntity
            {
                TaskId = vMTask.TaskId,
                Title = vMTask.Title,
                Description = vMTask.Description,
                AssigneeId = vMTask.AssigneeId,
                StatusId = vMTask.StatusId,
                StoryPoints = vMTask.StoryPoints,
                Attachment = vMTask.Attachment,
                CreatedBy = vMTask.CreatedBy,
                IsActive = vMTask.IsActive,
                File = vMTask.File
            };
            
            long result = await _ITask.SaveTask(taskEntity);

            return result;
        }

        public async Task<VMTaskDetailByUser> GetTaskDetailByUser(int userId)
        {
            var taskDetailByUser = await _ITask.GetTaskDetailByUser(userId);

            var vMTaskDetailByUser = new VMTaskDetailByUser
            {
                GetTaskDetailByUser = taskDetailByUser.GetTaskDetailByUser?
                    .Select(ws => new VMTask
                    {
                        TaskId = ws.TaskId,
                        Title = ws.Title,
                        Description = ws.Description,
                        AssigneeId = ws.AssigneeId,
                        StatusId = ws.StatusId,
                        StoryPoints = ws.StoryPoints,
                        CreatedBy = ws.CreatedBy,
                        Attachment = ws.Attachment,
                        IsActive = ws.IsActive

                    }).ToList()

            };

            return vMTaskDetailByUser;
        }

        public async Task<VMTaskDetailById> GetTaskDetailById(int taskId)
        {
            var taskDetailById = await _ITask.GetTaskDetailById(taskId);

            var vMTaskDetailById = new VMTaskDetailById
            {
                GetTaskDetailById = taskDetailById.GetTaskDetailById?
                    .Select(ws => new VMTask
                    {
                        TaskId = ws.TaskId,
                        Title = ws.Title,
                        Description = ws.Description,
                        AssigneeId = ws.AssigneeId,
                        StatusId = ws.StatusId,
                        StoryPoints = ws.StoryPoints,
                        CreatedBy = ws.CreatedBy,
                        Attachment = ws.Attachment,
                        IsActive = ws.IsActive,
                        StatusName = ws.StatusName,
                        AssigneeName = ws.AssigneeName,
                        AssigneeEmail = ws.AssigneeEmail

                    }).ToList()

            };

            return vMTaskDetailById;
        }

        
        public async Task<long> UpdateTaskStatus(VMUpdateTaskStatus vMUpdateTaskStatus)
        {
            // Convert ViewModel → Entity
            TaskEntity entity = new TaskEntity
            {
                TaskId = vMUpdateTaskStatus.TaskId,
                StatusId = vMUpdateTaskStatus.StatusId
            };

            long result = await _ITask.UpdateTaskStatus(entity);
            return result;
        }
    }
}
