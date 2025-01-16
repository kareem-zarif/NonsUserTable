using NonsUserTable.Enums;
using System.Text.Json.Serialization;

namespace NonsUserTable.APiDtos.Respose.RolePage
{
    public class RolePageResApiDto
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid PageId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccessTypeEnum AccessType { get; set; }
    }
}
