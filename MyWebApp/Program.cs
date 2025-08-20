//By default, this method configures Kestrel as the web server. Kestrel is a cross-platform web server for ASP.NET Core designed for high performance
var builder = WebApplication.CreateBuilder(args); //sets up we host
var app = builder.Build();


/*
. WebApplication.CreateBuilder(args) creates a new WebApplicationBuilder object.
. builder.Build() creates a new WebApplication object.
. The first app.Run() defines a delegate that takes a HttpContext object and returns a Task. The delegate writes "Hello world!" to the response.
. The second app.Run() starts the app.*/
app.Run(async context => //delegates added with .Run() are ALWAYS terminal...meaning they are the last middleware to run and only expect http object as a parameter 
{
    await context.Response.WriteAsync("Hello world!");
});


//If the request matches a defined route, the corresponding endpoint is executed. In this case, the app.MapGet("/", () => "Hello World!") endpoint handles requests to the root URL and returns the string 
//app.MapGet("/", () => "Hello, Alex Hamadey");

app.Run();
