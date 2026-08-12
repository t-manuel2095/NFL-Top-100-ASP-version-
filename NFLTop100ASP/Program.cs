using Microsoft.EntityFrameworkCore;
using NFLTop100ASP.Data;
using NFLTop100ASP.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPlayerService, PlayerService>();

//Keep this for now
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null;
});

/* When I add controllers
 * 
 * builder.Services.AddControllers()
 *      .AddJsonOptions(option =>
 *          {
 *              options.JsonSerializerOptions.PropertyNamingPolicy = null;
 *          });
 * 
 */

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Temporary smoke test — remove after Phase 3
app.MapGet("/api/smoke/count", async (AppDbContext db) =>
{
    var count = await db.players.CountAsync();
    return Results.Ok(new { count });
});

app.Run();