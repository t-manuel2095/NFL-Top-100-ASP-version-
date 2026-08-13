using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using NFLTop100ASP.Models;

/*
 * This is the database context: the bridge between the app and SQL Server through Entity Framework Core. The constructor takes options (including the connection string) 
 * from dependency injection and passes them to EF with base(options). DbSet<Player> players is the entry point for querying the Player/User table, like a typed collection 
 * you filter, count, or load by id. In general, one DbContext per database holds a DbSet for each entity you map, and services use it instead of writing raw SQL for everyday reads.
 */

namespace NFLTop100ASP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Player> players { get; set; }
    }
}