namespace NonsUserTable.APiDtos.Respose.Page
{
    public class PageResApiDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? PageNumber { get; set; }
        public string PageUrl { get; set; }
        public bool IsAlive { get; set; }

    }
}
