using System.ComponentModel.DataAnnotations;

namespace NonsUserTable.APiDtos.Request.UserRole
{
    public class UserRoleReqC_ApiDto
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid RoleId { get; set; }
    }
}
