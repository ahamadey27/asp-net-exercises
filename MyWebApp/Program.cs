
using Microsoft.AspNetCore.Rewrite; //added automatically after using UseRewriter middleware 

var builder = WebApplication.CreateBuilder(args); //sets up we host
var app = builder.Build();

//This code adds a URL rewriter middleware component that redirects requests from /history to /about. The AddRedirect() method takes two parameters: a regular expression pattern to match the request path, and the replacement path to redirect to.
app.UseRewriter(new RewriteOptions().AddRedirect("history", "about"));

//called endpoint routing 
app.MapGet("/", () => "Welcome to Contoso!");
app.MapGet("/about", () => "Contoso was founded in 2000");
//this starts the app
app.Run();

