


/************************WaitAll Metotuna Örnek******************************************/

public class Content
{
    public string? Site { get; set; }
    public int Length { get; set; }
}


public class Program
{
    private async static Task Main(string[] args)
    {
        Console.WriteLine("Main Thread: " + Thread.CurrentThread.ManagedThreadId);


        List<string> urlsList = new List<string>()
        {
            "https://www.google.com",
            "https://www.advocu.com",
            "https://www.amazon.com",
            "https://www.microsoft.com",
            "https://www.trendyol.com",
            "https://www.trello.com",
        };

        List<Task<Content>> taskList = new List<Task<Content>>();

        urlsList.ToList().ForEach(url =>
        {
            taskList.Add(GetContentAsync(url));
        });

        Console.WriteLine("WaitAll metodundan önce");

       var contents = await Task.WhenAll(taskList.ToArray());


        contents.ToList().ForEach((content) => Console.WriteLine(content.Site));
    }

    public static async Task<Content> GetContentAsync(string url)
    {
        Content content = new Content();

        try
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    await Task.Delay(5000);
                    content.Site = url;
                    content.Length = data.Length;
                    Console.WriteLine("GetContentAsync thread:" + Thread.CurrentThread.ManagedThreadId);
                }
                else
                {
                    // Handle error status codes, e.g., log the status code and reason
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}, Reason: {response.ReasonPhrase}");
                }
            }
        }
        catch (HttpRequestException ex)
        {
            // Handle exceptions that might occur during the HTTP request
            Console.WriteLine("HttpRequestException: " + ex.Message);
        }

        return content;
    }

}