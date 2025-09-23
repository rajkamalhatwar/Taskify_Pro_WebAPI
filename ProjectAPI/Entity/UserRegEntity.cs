namespace ProjectAPI.Entity
{
    public class UserRegEntity
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password  { get; set; }
        public string? MobileNumber { get; set; }
        public string? Gender { get; set; }  
        public bool IsActive { get; set; }
    }
}
