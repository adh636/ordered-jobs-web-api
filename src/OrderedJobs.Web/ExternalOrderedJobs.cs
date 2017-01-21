public class ExternalOrderedJobs {
    IHttpClient iHttpClient;

    public ExternalOrderedJobs(IHttpClient iHttpClient)
    {
        this.iHttpClient = iHttpClient;
    }
    public string GetResult(string testCase, string url) {
        var response = iHttpClient.GetAsync(url + "/" + testCase).Result;
        return response.Content.ReadAsStringAsync().Result;
    }
}