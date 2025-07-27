namespace ProjectAPI.Entity
{
    public class UserEntity
    {
        public List<UserDetail> Users { get; set; }
    }
    public class UserDetail
    {
        public int UserRoll { get; set; }
        public string UserName { get; set; }
    }
}
