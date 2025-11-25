namespace ProjectAPI.Entity
{
    public class TaskEntity
    {
        public int TaskId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? AssigneeId { get; set; }
        public int? StatusId { get; set; }
        public string? StatusName { get ; set; }
        public int? StoryPoints { get; set; }
        public string? Attachment { get; set; } 
        public int CreatedBy { get; set; }  
        public int? ModifiedBy { get; set; } 
        public bool IsActive { get; set; }
        public IFormFile? File { get; set; } // the uploaded file
        public string? AssigneeName { get; set; }
        public string? AssigneeEmail { get; set; }
    }
    public class TaskDropdownEntity
    {
        public List<WorkspaceEntity>? GetWorkspacesDropdown { get; set; }
        public List<UsersListEntity>? GetUserDropdown { get; set; }
    }
    public class WorkspaceEntity
    {
        public int Id { get; set; }
        public string? WorkSpaceName { get; set; }
 
    }
    public class UsersListEntity
    {
        public int Id { get; set; }
        public string? UserName { get; set; }

    }

    public class TaskUserDetailEntity 
    { 
        public List<UserDetailByIdEntity>? GetUserDetailById { get; set; } 
    } 

    public class UserDetailByIdEntity
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? Gender { get; set; }
        public string? ActiveStatus { get; set; }

    }

    public class TaskDetailByUserEntity
    {
        public List<TaskEntity>? GetTaskDetailByUser { get; set; } 
    }
    public class TaskDetailByIdEntity
    { 
        public List<TaskEntity>? GetTaskDetailById { get; set; }
    }
}
