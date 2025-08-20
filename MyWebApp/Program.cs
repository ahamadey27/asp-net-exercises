var builder = WebApplication.CreateBuilder(args); //sets up we host
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
