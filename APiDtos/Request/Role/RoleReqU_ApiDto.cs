using System.ComponentModel.DataAnnotations;

namespace NonsUserTable.APiDtos.Request.Role
{
    public class RoleReqU_ApiDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsAlive { get; set; }
    }
}
