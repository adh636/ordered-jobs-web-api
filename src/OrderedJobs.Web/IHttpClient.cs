using System.Net.Http;
using System.Threading.Tasks;

public interface IHttpClient {
    Task<HttpResponseMessage> GetAsync(string url);
}

public class OrderedJobsHttpClient: IHttpClient {
    HttpClient httpClient;
   public OrderedJobsHttpClient(HttpClient httpClient)
   {
       this.httpClient = httpClient;
   }
    public async Task<HttpResponseMessage> GetAsync(string url)
    {
        Task<HttpResponseMessage> response = httpClient.GetAsync(url);
        return response.Result;
    }
}