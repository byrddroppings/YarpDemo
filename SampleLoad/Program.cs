
const string service1Url = "http://localhost/version1";
const string service2Url = "http://localhost/version2";

while (true)
{
    await CallService(service1Url);
    await CallService(service2Url);
    await Task.Delay(500);
}

async Task CallService(string url)
{
    try
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
            WriteLine(await response.Content.ReadAsStringAsync());
        else
            WriteLine(response.StatusCode.ToString());
    }
    catch (Exception ex)
    {
        WriteLine(ex.Message);
    }
}

static void WriteLine(string message)
    => Console.WriteLine($"[{DateTime.Now.Ticks}] {message}");
