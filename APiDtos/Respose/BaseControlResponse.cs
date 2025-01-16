namespace NonsUserTable.APiDtos.Respose
{
    public class BaseControlResponse<TResonse>
        where TResonse : class
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RespinseResultEnum ResponseResult { get; set; }
        public TResonse Data { get; set; }
        public ErrorResponse ErrorDetails { get; set; }
    }
}
