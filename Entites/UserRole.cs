namespace NonsUserTable.Entites
{
    public class UserRole : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        //nav
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
