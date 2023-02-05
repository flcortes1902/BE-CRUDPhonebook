using Microsoft.EntityFrameworkCore;
using BE_CRUDPhonebook.Data;
using BE_CRUDPhonebook.Models;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cors
builder.Services.AddCors(options => options.AddPolicy("AllowOrigin",
                                    builder => builder.AllowAnyOrigin()
                                                      .AllowAnyHeader()
                                                      .AllowAnyMethod()));


builder.Services.Configure<JsonOptions>(
    options =>
    {
        options.SerializerOptions.PropertyNamingPolicy = null;
    });



// Add context

var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.MapPost("api/phones", async (Phonebook p, ApplicationDbContext db) =>
{
    db.Phonebooks.Add(p);
    await db.SaveChangesAsync();

    return Results.Created($"api/phones/{p.PhoneNumber}", p);
}
);

app.MapGet("api/phones/{id:int}", async (int id, ApplicationDbContext db) =>
{
    return await db.Phonebooks.FindAsync(id)
        is Phonebook p
        ? Results.Ok(p)
        : Results.NotFound(id);
});

app.MapGet("api/phones", async (ApplicationDbContext db) => await db.Phonebooks.ToListAsync());

app.MapPut("api/phones/{id:int}", async (int id, Phonebook p, ApplicationDbContext db) =>
{

    var phonebook = await db.Phonebooks.FindAsync(id);

    if (phonebook is null) return Results.NotFound();

    phonebook.FirstName = p.FirstName;
    phonebook.LastName = p.LastName;
    phonebook.PhoneNumber = p.PhoneNumber;
    phonebook.TextComments = p.TextComments;

    await db.SaveChangesAsync();

    return Results.Ok(phonebook);
});

app.MapDelete("api/phones/{id:int}", async (int id, ApplicationDbContext db) =>
{
    var phonebook = await db.Phonebooks.FindAsync(id);

    if (phonebook is null) return Results.NotFound();
    
        db.Phonebooks.Remove(phonebook);
        await db.SaveChangesAsync();    
    
    return Results.NoContent();
}
);

//app.UseAuthorization();

//app.MapControllers();

app.Run();


