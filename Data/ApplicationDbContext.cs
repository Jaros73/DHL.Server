using DHL.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DHL.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Tabulka pro dispečerské záznamy.
        /// </summary>
        public DbSet<DispatchModel> Dispatches { get; set; }

        /// <summary>
        /// Tabulka pro lokace.
        /// </summary>
        public DbSet<Location> Locations { get; set; }

        /// <summary>
        /// Tabulka pro typy dispečerských operací.
        /// </summary>
        public DbSet<DispatchType> DispatchTypes { get; set; }

        /// <summary>
        /// Tabulka pro klíče dispečerských operací.
        /// </summary>
        public DbSet<DispatchKey> DispatchKeys { get; set; }
    }
}
