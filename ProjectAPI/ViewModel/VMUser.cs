namespace ProjectAPI.ViewModel
{
    public class VMUser
    {
        public List<VMUserDetail> Users { get; set; }
    }
    public class VMUserDetail
    {
        public int UserRoll { get; set; }
        public string UserName { get; set; }
    }
}
