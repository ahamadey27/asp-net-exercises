using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

List <GameDto> games = [
    new (1, "The Legend of Zelda: Breath of the Wild", "Adventure", 59.99M, new DateOnly(2017, 3, 3)),
    new (2, "God of War", "Action", 49.99M, new DateOnly(2018, 4, 20)),
    new (3, "Minecraft", "Sandbox", 26.95M, new DateOnly(2011, 11, 18))
];

app.MapGet("/", () => "Hello World!");

app.Run();
