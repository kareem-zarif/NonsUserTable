namespace NonsUserTable.APiDtos.Respose
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
            TechErrorMessages = new List<string>();
        }
        public Guid ErrorCode { get; set; }
        public string FrindlyErrorMessage { get; set; }
        public List<string> TechErrorMessages { get; set; }

    }
}
