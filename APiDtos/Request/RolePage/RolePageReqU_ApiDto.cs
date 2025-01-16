namespace NonsUserTable.APiDtos.Request.RolePage
{
    public class RolePageReqU_ApiDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid RoleId { get; set; }
        [Required]
        public Guid PageId { get; set; }
        public AccessTypeEnum AccessType { get; set; } = AccessTypeEnum.readOnly;
    }
}
