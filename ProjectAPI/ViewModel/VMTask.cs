
using ProjectAPI.Entity;

namespace ProjectAPI.ViewModel
{
    public class VMTask
    {
        public int TaskId { get; set; }  // for insert = 0, update > 0
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? AssigneeId { get; set; }
        public int? StatusId { get; set; }
        public string? StatusName { get; set; }
        public int? StoryPoints { get; set; }
        public string? Attachment { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public IFormFile? File { get; set; } // the uploaded file
        public string? AssigneeName { get; set; }
        public string? AssigneeEmail { get; set; }
    }
    public class VMTaskDropdown
    {
        public List<VMWorkspace>? GetWorkspacesDropdown { get; set; }
        public List<VMUsersList>? GetUserDropdown { get; set; }

    }
    public class VMWorkspace 
    {
        public int Id { get; set; }
        public string? WorkSpaceName { get; set; }

    }
    public class VMUsersList
    {
        public int Id { get; set; }
        public string? UserName { get; set; }

    }

    public class VMTaskUserDetail 
    {
        public List<VMUserDetailById>? GetUserDetailById { get; set; }
    }

    public class VMUserDetailById
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? Gender { get; set; }
        public string? ActiveStatus { get; set; }

    }

    public class VMTaskDetailByUser
    {
        public List<VMTask>? GetTaskDetailByUser { get; set; }
        
    }
    public class VMTaskDetailById
    { 
        public List<VMTask>? GetTaskDetailById { get; set; }
    }

    public class VMUpdateTaskStatus
    {
        public int TaskId { get; set; }
        public int StatusId { get; set; } 
    }

}
