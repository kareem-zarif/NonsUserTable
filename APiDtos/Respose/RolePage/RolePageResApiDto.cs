using NonsUserTable.Enums;

namespace NonsUserTable.APiDtos.Respose.RolePage
{
    public class RolePageResApiDto
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid PageId { get; set; }
        public AccessTypeEnum AccessType { get; set; }
    }
}
