using PanVerse.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var handpans = new List<Handpan>
{
    new Handpan { Id = 1, Title = "D Kurd", Maker = "Ayasa", Scale = "D Minor", Price = 2800, Description = "Warm and meditative tone" },
    new Handpan { Id = 2, Title = "Integral", Maker = "PANArt", Scale = "A Pygmy", Price = 4200, Description = "The original handpan" },
    new Handpan { Id = 3, Title = "Spacedrum", Maker = "Metal Sounds", Scale = "C# Minor", Price = 1900, Description = "Great entry level pan" }
};
// GET all handpans
app.MapGet("/handpans", () =>
{
    return Results.Ok(handpans);
});

// GET single handpan by ID
app.MapGet("/handpans/{id}", (int id) =>
{
    var handpan = handpans.FirstOrDefault(h => h.Id == id);
    if (handpan is null)
        return Results.NotFound($"Handpan with ID {id} not found");
    return Results.Ok(handpan);
});


// POST — create a new handpan
app.MapPost("/handpans", (Handpan handpan) =>
{
    handpan.Id = handpans.Max(h => h.Id) + 1;
    handpans.Add(handpan);
    return Results.Created($"/handpans/{handpan.Id}", handpan);
});
// PUT — update an existing handpan
app.MapPut("/handpans/{id}", (int id, Handpan updated) =>
{
    var handpan = handpans.FirstOrDefault(h => h.Id == id);
    if (handpan is null)
        return Results.NotFound($"Handpan with ID {id} not found");

    handpan.Title = updated.Title;
    handpan.Maker = updated.Maker;
    handpan.Scale = updated.Scale;
    handpan.Price = updated.Price;
    handpan.Description = updated.Description;

    return Results.Ok(handpan);
});

// DELETE — remove a handpan
app.MapDelete("/handpans/{id}", (int id) =>
{
    var handpan = handpans.FirstOrDefault(h => h.Id == id);
    if (handpan is null)
        return Results.NotFound($"Handpan with ID {id} not found");

    handpans.Remove(handpan);
    return Results.NoContent();
});

app.Run();