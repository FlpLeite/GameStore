using GameStore.Infra;
using NHibernate;
using ISession = NHibernate.ISession;
using GameStore.Core.Entities;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddSingleton(_ => NHibernate.BuildSessionFactory(connString));
builder.Services.AddScoped<ISession>(sp => sp.GetRequiredService<ISessionFactory>().OpenSession());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/games", (ISession session) =>
{
    var games = session.Query<Game>().ToList();
    return Results.Ok(games);
});

app.MapPost("/games", (Game game, ISession session) =>
{
    session.Save(game);
    session.Flush();
    return Results.Created($"/games/{game.Id}", game);
});

app.Run();
