using System.Net.Http;
using System.Threading.Tasks;

public class ExternalOrderedJobs {
    public virtual string GetResult(string testCase, string url) {
        string orderedJob = GetExternalJobOrder(testCase, url).Result;
        return orderedJob;
    }

    public async Task<string> GetExternalJobOrder(string testCase, string url) {
        var httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.GetAsync(url + "/" + testCase);
        return await response.Content.ReadAsStringAsync();
    }
}