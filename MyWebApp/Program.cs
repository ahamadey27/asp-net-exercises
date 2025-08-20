//By default, this method configures Kestrel as the web server. Kestrel is a cross-platform web server for ASP.NET Core designed for high performance
var builder = WebApplication.CreateBuilder(args); //sets up we host

var app = builder.Build();

//If the request matches a defined route, the corresponding endpoint is executed. In this case, the app.MapGet("/", () => "Hello World!") endpoint handles requests to the root URL and returns the string 
app.MapGet("/", () => "Hello, Alex Hamadey");

app.Run();
