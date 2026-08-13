using Microsoft.EntityFrameworkCore;
using NFLTop100ASP.Data;
using NFLTop100ASP.Services;
using NFLTop100ASP.MIddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPlayerService, PlayerService>();
  
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();

// Index page
app.MapGet("/", () => Results.File(
    Path.Combine(app.Environment.WebRootPath!, "index.html"),
    "text/html"));

// Single about route only — /about and /about/ both match and conflict if both are mapped
app.MapGet("/about", () => Results.File(
    Path.Combine(app.Environment.WebRootPath!, "about.html"),
    "text/html"));

app.Run();