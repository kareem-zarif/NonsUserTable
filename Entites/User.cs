using System.ComponentModel.DataAnnotations;

namespace NonsUserTable.Entites
{
    public class User : BaseEntity<Guid>
    {
        public User()
        {
            UserRoles = new List<UserRole>();
        }
        public string UserName { get; set; }
        [EmailAddress]
        public string UserEmail { get; set; }
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[\W_])[a-zA-Z\d\W_]{9,16}$", ErrorMessage = "Password must be 9-16 characters long, include at least one uppercase letter and one symbol.")]
        public string UserPassword { get; set; }
        public string UserAddress { get; set; }
        [RegularExpression(@"^01[0|1|2]\d{8}$", ErrorMessage = $"phone must be 11 number starts with 01")]
        public string UserPhone { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }

        //nav
        public List<UserRole> UserRoles { get; set; }
    }
}
