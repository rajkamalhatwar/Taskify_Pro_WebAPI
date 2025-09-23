namespace ProjectAPI.Entity
{
    public class TaskEntity
    {
    }
    public class TaskDropdownEntity
    {
        public List<WorkspaceEntity>? GetWorkspacesDropdown { get; set; }
    }
    public class WorkspaceEntity
    {
        public int Id { get; set; }
        public string? WorkSpaceName { get; set; }
 
    }   
}
