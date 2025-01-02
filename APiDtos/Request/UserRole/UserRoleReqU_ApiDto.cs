using System.ComponentModel.DataAnnotations;

namespace NonsUserTable.APiDtos.Request.UserRole
{
    public class UserRoleReqU_ApiDto
    {
        [Required] //catch only null for reference types(nullable types) as the default value is null => so value types as guid has default values
        //so add ? nullable safety => make guid is nullable and guid.Empty() will be null and catched by required
        public Guid? Id { get; set; }
        [Required]
        public Guid? UserId { get; set; }
        [Required]
        public Guid? RoleId { get; set; }
    }
}
