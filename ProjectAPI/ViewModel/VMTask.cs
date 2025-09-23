
namespace ProjectAPI.ViewModel
{
    public class VMTask
    {
    }
    public class VMTaskDropdown
    {
        public List<VMWorkspace>? GetWorkspacesDropdown { get; set; } 
 
    }
    public class VMWorkspace 
    {
        public int Id { get; set; }
        public string? WorkSpaceName { get; set; }

    }
}
