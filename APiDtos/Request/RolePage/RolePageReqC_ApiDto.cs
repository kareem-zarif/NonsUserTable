using NonsUserTable.Enums;
using System.ComponentModel.DataAnnotations;

namespace NonsUserTable.APiDtos.Request.RolePage
{
    public class RolePageReqC_ApiDto
    {
        [Required]
        public Guid RoleId { get; set; }
        [Required]
        public Guid PageId { get; set; }
        public AccessTypeEnum AccessType { get; set; } = AccessTypeEnum.readOnly;

    }
}
