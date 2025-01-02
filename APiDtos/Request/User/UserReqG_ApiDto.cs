using System.ComponentModel.DataAnnotations;

namespace NonsUserTable.APiDtos.Request.User
{
    public class UserReqG_ApiDto
    {
        [EmailAddress]
        public string UserEmail { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
    }
}
