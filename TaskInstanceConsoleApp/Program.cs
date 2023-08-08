internal class Program
{

    private static async Task Main(string[] args)
    {
        Console.WriteLine("First step");
        var mytask = GetContent();
        Console.WriteLine("Second Step");
        var content = await mytask;
        Console.WriteLine("Third Step:"+ content.Length);

    }
    public static async Task<string> GetContent()
    {
        var content = await new HttpClient().GetStringAsync("https://www.google.com");
        return content;
    }
}
