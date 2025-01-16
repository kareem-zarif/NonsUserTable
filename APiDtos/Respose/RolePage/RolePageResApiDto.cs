using NonsUserTable.Enums;
<<<<<<< HEAD
using System.Text.Json.Serialization;
=======
>>>>>>> 8b739017b50376684d0193e40881f9e6535cd14b
<<<<<<< HEAD
=======
>>>>>>> 8b739017b50376684d0193e40881f9e6535cd14b

namespace NonsUserTable.APiDtos.Respose.RolePage
{
    public class RolePageResApiDto
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid PageId { get; set; }
<<<<<<< HEAD
        [JsonConverter(typeof(JsonStringEnumConverter))]
=======
>>>>>>> 8b739017b50376684d0193e40881f9e6535cd14b
        public AccessTypeEnum AccessType { get; set; }
    }
}
