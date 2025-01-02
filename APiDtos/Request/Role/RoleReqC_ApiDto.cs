using System.ComponentModel.DataAnnotations;

namespace NonsUserTable.APiDtos.Request.Role
{
    public class RoleReqC_ApiDto
    {
        [Required]
        public string Name { get; set; }
        public bool IsAlive { get; set; }
    }
}
