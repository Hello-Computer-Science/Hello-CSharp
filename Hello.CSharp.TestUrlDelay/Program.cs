var random = new Random();

using var http = new HttpClient();

var urls = new List<string> { "www.baidu.com", "www.google.com", "www.bilibili.com" };
var queries = urls.Select(url => Task.Factory.StartNew(() => TestDelay(url))); // You can switch to `TestActualDelay` function
var fastest = await await await Task.WhenAny(queries);

Console.WriteLine($"{DateTime.Now:O} {fastest.Item2} ms -> Url {fastest.Item1}");

return;

async Task<(string, double)> TestDelay(string url)
{
    var delay = random.Next(1, 15) * 300;
    Console.WriteLine($"{DateTime.Now:O} Testing {url} ... (It will took {delay} ms)");
    for (var i = 0; i < 3; ++i) // This line with below 4 lines should be changed to GET method on url
    {
        await Task.Delay(delay / 3);
        Console.WriteLine($"\t Test of {url} is still alive !");
    }
    return (url, delay);
}

async Task<(string, double)> TestActualDelay(string url)
{
    var begin = DateTime.Now;
    Console.WriteLine($"{begin:O} Testing {url} ...");
    var response = await http.GetAsync($"https://{url}");
    var end = DateTime.Now;
    
    return (url, (begin - end).Milliseconds);
}
