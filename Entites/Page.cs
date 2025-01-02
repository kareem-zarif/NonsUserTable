namespace NonsUserTable.Entites
{
    public class Page : BaseEntity<Guid>
    {
        public Page()
        {
            RolePages = new List<RolePage>();
        }
        public string Name { get; set; }
        public int PageNumber { get; set; } // ? to make it nullable type
        public string PageUrl { get; set; }
        public bool IsAlive { get; set; }
        //nav
        public List<RolePage> RolePages { get; set; }
    }
}
