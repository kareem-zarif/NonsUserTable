namespace NonsUserTable.APiDtos.Request.Page
{
    public class PageReqU_ApiDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? PageNumber { get; set; }
        [Required]
        public string PageUrl { get; set; }
        public bool IsAlive { get; set; }
    }
}
