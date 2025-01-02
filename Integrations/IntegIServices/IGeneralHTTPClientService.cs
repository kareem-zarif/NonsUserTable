namespace NonsUserTable.Integrations.IntegIServices
{
    public interface IGeneralHttpClientService
    {
        Task<R> GetAsync<R>(string url);
        Task<R> GetAllAsync<R>(string url);
        Task<R> PostAsync<Q, R>(string url, Q data);
        Task<R> PutAsync<Q, R>(string url, Q data);
        Task<R> DeleteAsync<R>(string url);
    }
}
