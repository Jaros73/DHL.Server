using System.Collections.Generic;
using DHL.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DHL.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<DispatchModel> Dispatches { get; set; }
    }
}

