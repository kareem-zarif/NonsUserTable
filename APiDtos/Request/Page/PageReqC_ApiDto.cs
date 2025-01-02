using System.ComponentModel.DataAnnotations;

namespace NonsUserTable.APiDtos.Request.Page
{
    public class PageReqC_ApiDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int? PageNumber { get; set; }
        [Required]
        public string PageUrl { get; set; }
        public bool IsAlive { get; set; }

    }
}
