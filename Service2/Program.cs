using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => $"Hello from Service2-Instance{Environment.GetEnvironmentVariable("INSTANCE")} {Environment.MachineName}");

app.MapGet("/about", () => Assembly.GetExecutingAssembly().FullName);

app.MapGet("/health", () => "OK");

app.Run();