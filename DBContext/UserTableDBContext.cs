using Microsoft.EntityFrameworkCore;
using NonsUserTable.Entites;
using NonsUserTable.EntitysTypeConfig;

namespace NonsUserTable.DBContext
{
    public class UserTableDBContext : DbContext
    {
        public UserTableDBContext(DbContextOptions<UserTableDBContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //configuration
            modelBuilder.ApplyConfiguration(new UserTypeConfig());
            modelBuilder.ApplyConfiguration(new RoleTypeConfig());
            modelBuilder.ApplyConfiguration(new UserRoleTypeConfig());
            modelBuilder.ApplyConfiguration(new PageTypeConfig());
            modelBuilder.ApplyConfiguration(new RolePageTypeConfig());
            //seeding User
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("fefbb940-7fed-4746-bbe3-360a2a165a96"),
                    UserName = "UseOne",
                    UserEmail = "UserOne@gmail.com",
                    UserPassword = "0123456789Kk@_",
                    UserPhone = "01276367236"
                }
            );
            //seeding Role
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = Guid.Parse("fefbb940-7fed-4746-bbe3-360a2a165a77"),
                    Name = "USER",
                    IsAlive = true,
                },
                 new Role
                 {
                     Id = Guid.Parse("fefbb940-7fed-4746-bbe3-360a2a165a78"),
                     Name = "ADMIN",
                     IsAlive = true,
                 }
                );
            //seeding User_Role 
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = Guid.Parse("2AEF49EA-5699-4001-8E32-BE3DEC1FED5D"),
                    RoleId = Guid.Parse("fefbb940-7fed-4746-bbe3-360a2a165a77"),
                    UserId = Guid.Parse("fefbb940-7fed-4746-bbe3-360a2a165a96")
                }
                );
            //seeding page
            modelBuilder.Entity<Page>().HasData(
                new Page
                {
                    Id = Guid.Parse("C1375539-E7E7-425E-BBCD-1B381DBAB874"),
                    Name = "Home",
                    PageNumber = 1,
                    PageUrl = "/Home",
                    IsAlive = true,
                }
                );
            //seeding Role_Page
            modelBuilder.Entity<RolePage>().HasData(
                new RolePage
                {
                    Id = Guid.Parse("B5438722-ADAF-45CD-987C-CDADB5C95155"),
                    AccessType = Enums.AccessTypeEnum.readOnly,
                    RoleId = Guid.Parse("fefbb940-7fed-4746-bbe3-360a2a165a77"),
                    PageId = Guid.Parse("C1375539-E7E7-425E-BBCD-1B381DBAB874")
                },
                 new RolePage
                 {
                     Id = Guid.Parse("62ED6BB7-5EDD-45E4-AA18-69E386503BAD"),
                     AccessType = Enums.AccessTypeEnum.Admin,
                     RoleId = Guid.Parse("fefbb940-7fed-4746-bbe3-360a2a165a78"),
                     PageId = Guid.Parse("C1375539-E7E7-425E-BBCD-1B381DBAB874")
                 }
                );
        }
        //DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<RolePage> RolePages { get; set; }
    }
}
