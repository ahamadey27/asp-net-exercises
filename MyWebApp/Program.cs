//By default, this method configures Kestrel as the web server. Kestrel is a cross-platform web server for ASP.NET Core designed for high performance
var builder = WebApplication.CreateBuilder(args); //sets up we host
var app = builder.Build();


/*
. WebApplication.CreateBuilder(args) creates a new WebApplicationBuilder object.
. builder.Build() creates a new WebApplication object.
. The first app.Run() defines a delegate that takes a HttpContext object and returns a Task. The delegate writes "Hello world!" to the response.
. The second app.Run() starts the app.*/
//delegates added with .Run() are ALWAYS terminal...meaning they are the last middleware to run and only expect http object as a parameter 

/*
. app.Use() defines a middleware component that:
. Writes "Hello from middleware 1. Passing to the next middleware!" to the response.
. Passes the request to the next middleware component in the pipeline and waits for it to complete with await next.Invoke().
. After the next component in the pipeline completes, it writes "Hello from middleware 1 again!"
. The first app.Run() defines a middleware component that writes "Hello from middleware 2!" to the response.
. The second app.Run() starts the app.

*/

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello from middleware 1. Passing to the next middleware!\r\n");

    // Call the next middleware in the pipeline
    await next.Invoke();

    await context.Response.WriteAsync("Hello from middleware 1 again!\r\n");
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from middleware 2!\r\n");
});

app.Run();


//If the request matches a defined route, the corresponding endpoint is executed. In this case, the app.MapGet("/", () => "Hello World!") endpoint handles requests to the root URL and returns the string 
//app.MapGet("/", () => "Hello, Alex Hamadey");

