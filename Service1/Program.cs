using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello from Service1");

app.MapGet("/about", () => Assembly.GetExecutingAssembly().FullName);

app.Run();
