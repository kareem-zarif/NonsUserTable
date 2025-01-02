namespace NonsUserTable.Entites
{
    public class Role : BaseEntity<Guid>
    {
        private string _name;
        public Role()
        {
            UserRoles = new List<UserRole>();
            RolePages = new List<RolePage>();
        }
        public string Name
        {
            get => _name;
            set => _name = value?.ToUpper(); // but best practice to put toUpper() in service or repo
        }
        public bool IsAlive { get; set; }
        //nav
        public List<UserRole> UserRoles { get; set; }
        public List<RolePage> RolePages { get; set; }
    }
}
