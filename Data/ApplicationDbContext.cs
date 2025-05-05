using Microsoft.EntityFrameworkCore;
using DHL.Server.Models.Entities;
using DHL.Server.Models.DTO;

namespace DHL.Server.Data
{
    /// <summary>
    /// Hlavní databázový kontext aplikace.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Konstruktor s injektovanými možnostmi konfigurace.
        /// </summary>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Tabulka dispečerských záznamů.
        /// </summary>
        public DbSet<DispatchModelEntity> Dispatches { get; set; }

        /// <summary>
        /// Tabulka typů dispečerských operací.
        /// </summary>
        public DbSet<DispatchTypeEntity> DispatchTypes { get; set; }

        /// <summary>
        /// Tabulka klíčů dispečerských operací.
        /// </summary>
        public DbSet<DispatchKeyEntity> DispatchKeys { get; set; }

        /// <summary>
        /// Tabulka lokací.
        /// </summary>
        public DbSet<LocationEntity> Locations { get; set; }

        /// <summary>
        /// Tabulka výkonů mechanizace.
        /// </summary>
        public DbSet<Machining> Machinings { get; set; }

        /// <summary>
        /// Tabulka strojů.
        /// </summary>
        public DbSet<Machine> Machines { get; set; }

        /// <summary>
        /// Tabulka přiřazení stroje k výkonu.
        /// </summary>
        public DbSet<MachiningMachine> MachiningMachines { get; set; }

        /// <summary>
        /// Tabulka technologických skupin.
        /// </summary>
        public DbSet<TechnologicalGroup> TechnologicalGroups { get; set; }

        /// <summary>
        /// Tabulka přepravních obalů.
        /// </summary>
        public DbSet<Crate> Crates { get; set; }

        /// <summary>
        /// Tabulka přiřazení obalu k technologické skupině.
        /// </summary>
        public DbSet<TechnologicalGroupCrate> TechnologicalGroupCrates { get; set; }

        /// <summary>
        /// Tabulka přiřazení stroje k lokaci.
        /// </summary>
        public DbSet<LocationMachine> LocationMachines { get; set; }

        public DbSet<RegionalReportEntity> RegionalReports { get; set; }
        public DbSet<AttachmentEntity> Attachments { get; set; }

        /// <summary>
        /// Definuje vztahy mezi entitami.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // MachiningMachine: Composite Key
            modelBuilder.Entity<MachiningMachine>()
                .HasKey(mm => new { mm.MachiningId, mm.MachineValue });

            modelBuilder.Entity<MachiningMachine>()
                .HasOne<Machining>()
                .WithMany()
                .HasForeignKey(mm => mm.MachiningId);

            modelBuilder.Entity<MachiningMachine>()
                .HasOne<Machine>()
                .WithMany()
                .HasForeignKey(mm => mm.MachineValue);

            // TechnologicalGroupCrate: Composite Key
            modelBuilder.Entity<TechnologicalGroupCrate>()
                .HasKey(tgc => new { tgc.TechnologicalGroupValue, tgc.CrateValue });

            modelBuilder.Entity<TechnologicalGroupCrate>()
                .HasOne<TechnologicalGroup>()
                .WithMany()
                .HasForeignKey(tgc => tgc.TechnologicalGroupValue);

            modelBuilder.Entity<TechnologicalGroupCrate>()
                .HasOne<Crate>()
                .WithMany()
                .HasForeignKey(tgc => tgc.CrateValue);

            // LocationMachine: Composite Key
            modelBuilder.Entity<LocationMachine>()
                .HasKey(lm => new { lm.LocationId, lm.MachineValue });

            modelBuilder.Entity<LocationMachine>()
                .HasOne<LocationEntity>()
                .WithMany()
                .HasForeignKey(lm => lm.LocationId);

            modelBuilder.Entity<LocationMachine>()
                .HasOne<Machine>()
                .WithMany()
                .HasForeignKey(lm => lm.MachineValue);

            modelBuilder.Entity<AttachmentEntity>()
                .HasOne(a => a.RegionalReport)
                .WithMany(r => r.Attachments)
                .HasForeignKey(a => a.RegionalReportId);

        }
    }
}