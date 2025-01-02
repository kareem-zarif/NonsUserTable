using NonsUserTable.Integrations.IntegIServices;

namespace NonsUserTable.Integrations.IntegServices
{
    public class GeneralHTTPClientService : IGeneralHttpClientService
    {
        private readonly HttpClient _httpClient;

        public GeneralHTTPClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //delete a resource
        public async Task<R> DeleteAsync<R>(string url)
        {
            try
            {
                var httpResponse = await _httpClient.DeleteAsync(url);
                httpResponse.EnsureSuccessStatusCode();
                //deserializes the JSON content into an object of type R.
                var responseR = await httpResponse.Content.ReadFromJsonAsync<R>();
                return responseR;
            }
            catch (Exception ex)
            {
                throw new Exception($"HTTP error when deleting resource through : {url}");
            }
        }

        public virtual async Task<R> GetAllAsync<R>(string url)
        {
            try
            {
                var httpResponse = await _httpClient.GetAsync(url);
                //httpResponse.EnsureSuccessStatusCode();
                if (!httpResponse.IsSuccessStatusCode)
                {
                    var errorContent = await httpResponse.Content.ReadAsStringAsync();

                    throw new Exception(errorContent);
                }

                var responseR = await httpResponse.Content.ReadFromJsonAsync<R>();


                return responseR;
            }
            catch (Exception ex)
            {
                throw new Exception($"HTTP error when getting all resources through : {url}");
            }
        }

        public async Task<R> GetAsync<R>(string url)
        {
            try
            {
                var httpResponse = await _httpClient.GetAsync(url);
                httpResponse.EnsureSuccessStatusCode();
                var resourceResponse = await httpResponse.Content.ReadFromJsonAsync<R>();

                return resourceResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"error getting a http resource : {url}");
            }
        }

        public async Task<R> PostAsync<Q, R>(string url, Q data)
        {
            try
            {
                var httpResponse = await _httpClient.PostAsJsonAsync(url, data);
                httpResponse.EnsureSuccessStatusCode();
                var resourceResponse = await httpResponse.Content.ReadFromJsonAsync<R>();
                return resourceResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"http error creating a resource through : {url}");
            }
        }

        public async Task<R> PutAsync<Q, R>(string url, Q data)
        {
            try
            {
                var httpResponse = await _httpClient.PutAsJsonAsync(url, data);
                httpResponse.EnsureSuccessStatusCode();
                var resourceResponse = await httpResponse.Content.ReadFromJsonAsync<R>();

                return resourceResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"http error updating a resource throught : {url}");
            }
        }
    }
}
