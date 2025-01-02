namespace NonsUserTable.APiDtos.Respose.User
{
    public class UserResApiDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string? UserAddress { get; set; }
        public string? UserPhone { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
    }
}
