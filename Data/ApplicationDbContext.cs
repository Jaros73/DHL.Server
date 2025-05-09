using Microsoft.EntityFrameworkCore;
using DHL.Server.Models.Entities;

namespace DHL.Server.Data
{
    /// <summary>
    /// Hlavní databázový kontext aplikace.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DispatchTypeEntity> DispatchTypes { get; set; }
        public DbSet<DispatchKeyEntity> DispatchKeys { get; set; }
        public DbSet<DispatchModelEntity> DispatchModels { get; set; }
        public DbSet<KlicEntity> Klics { get; set; }
        public DbSet<KurzEntity> Kurzs { get; set; }
        public DbSet<KurzyPEEntity> KurzyPEs { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }
        public DbSet<LokaceStrojeEntity> LokaceStrojes { get; set; }
        public DbSet<MimKurzEntity> MimKurzs { get; set; }
        public DbSet<ObalEntity> Obals { get; set; }
        public DbSet<PrepravceEntity> Prepravces { get; set; }
        public DbSet<PrilohyEntity> Prilohys { get; set; }   
        public DbSet<PripojVozidloEntity> PripojVozidlos { get; set; }
        public DbSet<RegionalReportEntity> RegionalReports { get; set; }
        public DbSet<StrojEntity> Strojs { get; set; }
        public DbSet<TechnologicalGroupCrateEntity> TechnologicalGroupCrates { get; set; }
        public DbSet<TechnologicalGroupEntity> TechnologicalGroups { get; set; }
        public DbSet<VozidloEntity> Vozidlos { get; set; }
        public DbSet<VykonStrojeEntity> VykonStrojes { get; set; }
        public DbSet<VykonStrojEntity> VykonStrojs { get; set; }
        public DbSet<ZastavkaEntity> Zastavkas { get; set; }
        public DbSet<ZatezAPEntity> ZatezAPs { get; set; }
        public DbSet<ZbytekEntity> Zbyteks { get; set; }
        public DbSet<ZpozdeniKurzuEntity> ZpozdeniKurzus { get; set; }



        /// <summary>
        /// Definuje vztahy mezi entitami.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TechnologicalGroupCrate: Composite Key
            modelBuilder.Entity<TechnologicalGroupCrateEntity>()
                .HasKey(tgc => new { tgc.TechnologicalGroupValue, tgc.CrateValue });

            modelBuilder.Entity<LokaceStrojeEntity>()
                .HasKey(e => new { e.LocationId, e.MachineValue });

            modelBuilder.Entity<StrojEntity>()
                .HasKey(x => new { x.StrojId, x.StrojValue });

            modelBuilder.Entity<TechnologicalGroupCrateEntity>()
                .HasOne<TechnologicalGroupEntity>()
                .WithMany()
                .HasForeignKey(tgc => tgc.TechnologicalGroupValue);

            modelBuilder.Entity<DispatchModelEntity>()
                .HasOne<LocationEntity>()
                .WithMany()
                .HasForeignKey(d => d.LocationId);

            modelBuilder.Entity<LokaceStrojeEntity>()
                .HasOne<LocationEntity>()
                .WithMany()
                .HasForeignKey(l => l.LocationId);

            modelBuilder.Entity<PrilohyEntity>()
                .HasOne(p => p.RegionalReport)
                .WithMany(r => r.Prilohy)
                .HasForeignKey(p => p.RegionalReportId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RegionalReportEntity>()
                .HasOne(r => r.Location)
                .WithMany()
                .HasForeignKey(r => r.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ZbytekEntity>()
                .HasOne(z => z.Location)
                .WithMany()
                .HasForeignKey(z => z.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Optional: explicitní mapování tabulek
            modelBuilder.Entity<DispatchKeyEntity>().ToTable("DispatchKeys");
            modelBuilder.Entity<DispatchModelEntity>().ToTable("DispatchModels");
            modelBuilder.Entity<DispatchTypeEntity>().ToTable("DispatchTypes");
            modelBuilder.Entity<KlicEntity>().ToTable("Klics");
            modelBuilder.Entity<KurzEntity>().ToTable("Kurzs");
            modelBuilder.Entity<KurzyPEEntity>().ToTable("KurzyPEs");
            modelBuilder.Entity<LocationEntity>().ToTable("Locations");
            modelBuilder.Entity<LokaceStrojeEntity>().ToTable("LokaceStrojes");
            modelBuilder.Entity<MimKurzEntity>().ToTable("MimKurzs");
            modelBuilder.Entity<ObalEntity>().ToTable("Obals");
            modelBuilder.Entity<PrepravceEntity>().ToTable("Prepravces");
            modelBuilder.Entity<PrilohyEntity>().ToTable("Prilohys"); 
            modelBuilder.Entity<PripojVozidloEntity>().ToTable("PripojVozidlos");
            modelBuilder.Entity<RegionalReportEntity>().ToTable("RegionalReports");
            modelBuilder.Entity<StrojEntity>().ToTable("Strojs");
            modelBuilder.Entity<TechnologicalGroupCrateEntity>().ToTable("TechnologicalGroupCrates");
            modelBuilder.Entity<TechnologicalGroupEntity>().ToTable("TechnologicalGroups");
            modelBuilder.Entity<VozidloEntity>().ToTable("Vozidlos");
            modelBuilder.Entity<VykonStrojeEntity>().ToTable("VykonStrojes");
            modelBuilder.Entity<VykonStrojEntity>().ToTable("VykonStrojs");
            modelBuilder.Entity<ZastavkaEntity>().ToTable("Zastavkas");
            modelBuilder.Entity<ZatezAPEntity>().ToTable("ZatezAPs");
            modelBuilder.Entity<ZbytekEntity>().ToTable("Zbyteks");
            modelBuilder.Entity<ZpozdeniKurzuEntity>().ToTable("ZpozdeniKurzus");


        }
    }
}
