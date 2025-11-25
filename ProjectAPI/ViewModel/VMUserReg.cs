namespace ProjectAPI.ViewModel
{
    public class VMUserReg
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? MobileNumber { get; set; }
        public int Gender { get; set; }
        public bool IsActive { get; set; }
    }
}
