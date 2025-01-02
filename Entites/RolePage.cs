using NonsUserTable.Enums;

namespace NonsUserTable.Entites
{
    public class RolePage : BaseEntity<Guid>
    {
        public Guid RoleId { get; set; }
        public Guid PageId { get; set; }
        public AccessTypeEnum AccessType { get; set; } = AccessTypeEnum.readOnly;
        //nav
        public Role Role { get; set; }
        public Page Page { get; set; }
    }
}
