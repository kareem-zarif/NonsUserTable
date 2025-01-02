using NonsUserTable.Integrations.IntegIServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NonsUserTable.Integrations.IntegServices
{
    public class PageHTTPClientService : GeneralHTTPClientService, IPageHTTPClientService
    {
        private readonly HttpClient _hTTPClient;
        public PageHTTPClientService(HttpClient httpClient) : base(httpClient)
        {
            _hTTPClient = httpClient;
        }
        public override async Task<R> GetAllAsync<R>(string url)
        {
            try
            {
                var httpResponse = await _hTTPClient.GetAsync(url);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    var errorContent = await httpResponse.Content.ReadAsStringAsync();
                    throw new Exception(errorContent);
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
                };

                //for debugging
                var rawContent = await httpResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"Raw Response Content: {rawContent}");

                var responseList = JsonSerializer.Deserialize<R>(rawContent, options);

                //var responseList = await httpResponse.Content.ReadFromJsonAsync<R>(options);

                return responseList;
            }
            catch (JsonException jsEx)
            {
                throw new Exception($"json desearlizing error when geeting all resourcec through : {url} => {jsEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"httpPages error getting all resources through : {url}");
            }
        }
    }
}
