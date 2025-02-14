var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MongoDbService>();
builder.Services.AddSingleton<AutorRepository>();
builder.Services.AddSingleton<MangaRepository>();
builder.Services.AddSingleton<ArcoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/autores", async (AutorRepository autorRepo) =>
{
    var autores = await autorRepo.GetAllAsync();
    return Results.Ok(autores);
});

app.MapGet("/autores/{id}", async (string id, AutorRepository autorRepo) =>
{
    var autor = await autorRepo.GetByIdAsync(id);
    return autor is not null ? Results.Ok(autor) : Results.NotFound("Autor não encontrado.");
});

app.MapPost("/autores", async (Autor autor, AutorRepository autorRepo) =>
{
    await autorRepo.CreateAsync(autor);
    return Results.Created($"/autores/{autor.Id}", autor);
});

app.MapPut("/autores/{id}", async (string id, Autor autor, AutorRepository autorRepo) =>
{
    var autorExistente = await autorRepo.GetByIdAsync(id);
    if (autorExistente is null)
    {
        return Results.NotFound("Autor não encontrado.");
    }
    await autorRepo.UpdateAsync(id, autor);
    return Results.NoContent();
});

app.MapDelete("/autores/{id}", async (string id, AutorRepository autorRepo) =>
{
    var autorExistente = await autorRepo.GetByIdAsync(id);
    if (autorExistente is null)
    {
        return Results.NotFound("Autor não encontrado.");
    }
    await autorRepo.DeleteAsync(id);
    return Results.NoContent();
});





app.Run();

