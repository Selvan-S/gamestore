using GameStore.Api.Dtos;

const string GetGameEndpointName = "GetGame";

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new (1, "Street Fighter II", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
    new (2, "Final Fantasy XIV", "Roleplaying", 59.99M, new DateOnly(2010, 9, 30)),
    new (3, "FIFA 23", "Sports", 69.99M, new DateOnly(2022, 9, 27)),
    new (4, "The Legend of Zelda: Breath of the Wild", "Action-Adventure", 59.99M, new DateOnly(2017, 3, 3)),
    new (5, "Elden Ring", "Action RPG", 59.99M, new DateOnly(2022, 2, 25)),
    new (6, "God of War", "Action-Adventure", 49.99M, new DateOnly(2018, 4, 20)),
    new (7, "Super Mario Odyssey", "Platformer", 59.99M, new DateOnly(2017, 10, 27)),
    new (8, "Hollow Knight", "Metroidvania", 14.99M, new DateOnly(2017, 2, 24)),
    new (9, "Red Dead Redemption 2", "Action-Adventure", 59.99M, new DateOnly(2018, 10, 26)),
    new (10, "Cyberpunk 2077", "RPG", 59.99M, new DateOnly(2020, 12, 10))
];

// GET /games
app.MapGet("/games", () => games);

// GET /games/1
app.MapGet("/games/{id}", (int id) =>
{
    var game = games.Find(games => games.Id == id);
    if (game is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(game);
})
.WithName(GetGameEndpointName);

// POST /games
app.MapPost("/games", (CreateGameDto newGame) =>
{
    if (newGame is null)
    {
        return Results.BadRequest();
    }
    var game = new GameDto(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);
    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});

app.Run();
