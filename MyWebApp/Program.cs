//In this exercise, you create a custom middleware component that logs request details to the console.
using Microsoft.AspNetCore.Rewrite; //added automatically after using UseRewriter middleware 

var builder = WebApplication.CreateBuilder(args); //sets up we host
var app = builder.Build();

/*
. app.Use() adds a custom middleware component to the pipeline. The component takes a HttpContext object and a RequestDelegate  object as parameters.
. The delegate writes the request method, path, and response status code to the console.
. await next() calls the next middleware component in the pipeline.
*/
app.Use(async (context, next) =>
{
    await next(); //this passes the 302 redirect middleware component 
    Console.WriteLine($"{context.Request.Method} {context.Request.Path} {context.Response.StatusCode}");
});

//This code adds a URL rewriter middleware component that redirects requests from /history to /about. The AddRedirect() method takes two parameters: a regular expression pattern to match the request path, and the replacement path to redirect to.
app.UseRewriter(new RewriteOptions().AddRedirect("history", "about"));

//called endpoint routing 
app.MapGet("/", () => "Welcome to Contoso!");
app.MapGet("/about", () => "Contoso was founded in 2000");




//this starts the app
app.Run();

