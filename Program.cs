using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PhraseBingo;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

HttpClient http = new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
};
string[] phrases = await http.GetFromJsonAsync<string[]>("Phrases.json");
//string content = await httpResponse.Content.ReadAsStringAsync();

//Console.Write(content);
//string[] phrases = content.Split("\\n");

Console.WriteLine(phrases.Length);

builder.Services.AddScoped(sp => http);
builder.Services.AddScoped(sp => new BingoCardService(phrases));

await builder.Build().RunAsync();
