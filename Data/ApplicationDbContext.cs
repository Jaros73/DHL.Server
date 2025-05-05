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

        public DbSet<DispatchModelEntity> Dispatches { get; set; }
        public DbSet<DispatchTypeEntity> DispatchTypes { get; set; }
        public DbSet<DispatchKeyEntity> DispatchKeys { get; set; }

        public DbSet<LocationEntity> Locations { get; set; }

        public DbSet<MachiningEntity> Machinings { get; set; } 
        public DbSet<MachineEntity> Machines { get; set; }
        public DbSet<MachiningMachineEntity> MachiningMachines { get; set; }

        public DbSet<TechnologicalGroupEntity> TechnologicalGroups { get; set; }
        public DbSet<CrateEntity> Crates { get; set; }
        public DbSet<TechnologicalGroupCrateEntity> TechnologicalGroupCrates { get; set; }
        public DbSet<LocationMachineEntity> LocationMachines { get; set; }

        public DbSet<RegionalReportEntity> RegionalReports { get; set; }
        public DbSet<AttachmentEntity> Attachments { get; set; }

        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<IrregularCourseEntity> IrregularCourses { get; set; }
        public DbSet<RemainderEntity> Remainders { get; set; }
        public DbSet<KurzyPEEntity> KurzyPE { get; set; }
        public DbSet<ZatezAPEntity> ZatezAP { get; set; }

        public DbSet<CourseDelayReasonEntity> CourseDelayReasons { get; set; }
        public DbSet<TransporterEntity> Transporters { get; set; }
        public DbSet<StopEntity> Stops { get; set; }
        public DbSet<VehicleEntity> Vehicles { get; set; }
        public DbSet<TrailerEntity> Trailers { get; set; }

        /// <summary>
        /// Definuje vztahy mezi entitami.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // MachiningMachine: Composite Key
            modelBuilder.Entity<MachiningMachineEntity>()
                .HasKey(mm => new { mm.MachiningId, mm.MachineValue });

            modelBuilder.Entity<MachiningMachineEntity>()
                .HasOne<MachiningEntity>()
                .WithMany()
                .HasForeignKey(mm => mm.MachiningId);

            modelBuilder.Entity<MachiningMachineEntity>()
                .HasOne<MachineEntity>()
                .WithMany()
                .HasForeignKey(mm => mm.MachineValue);

            // TechnologicalGroupCrate: Composite Key
            modelBuilder.Entity<TechnologicalGroupCrateEntity>()
                .HasKey(tgc => new { tgc.TechnologicalGroupValue, tgc.CrateValue });

            modelBuilder.Entity<TechnologicalGroupCrateEntity>()
                .HasOne<TechnologicalGroupEntity>()
                .WithMany()
                .HasForeignKey(tgc => tgc.TechnologicalGroupValue);

            modelBuilder.Entity<TechnologicalGroupCrateEntity>()
                .HasOne<CrateEntity>()
                .WithMany()
                .HasForeignKey(tgc => tgc.CrateValue);

            // LocationMachine: Composite Key
            modelBuilder.Entity<LocationMachineEntity>()
                .HasKey(lm => new { lm.LocationId, lm.MachineValue });

            modelBuilder.Entity<LocationMachineEntity>()
                .HasOne<LocationEntity>()
                .WithMany()
                .HasForeignKey(lm => lm.LocationId);

            modelBuilder.Entity<LocationMachineEntity>()
                .HasOne<MachineEntity>()
                .WithMany()
                .HasForeignKey(lm => lm.MachineValue);

            // RegionalReport ↔ Attachments (1:N)
            modelBuilder.Entity<AttachmentEntity>()
                .HasOne(a => a.RegionalReport)
                .WithMany(r => r.Attachments)
                .HasForeignKey(a => a.RegionalReportId);

            // Optional: explicitní mapování tabulek
            modelBuilder.Entity<DispatchModelEntity>().ToTable("Dispatches");
            modelBuilder.Entity<DispatchTypeEntity>().ToTable("DispatchTypes");
            modelBuilder.Entity<DispatchKeyEntity>().ToTable("DispatchKeys");
            modelBuilder.Entity<LocationEntity>().ToTable("Locations");
            modelBuilder.Entity<MachiningEntity>().ToTable("Machinings");
            modelBuilder.Entity<MachineEntity>().ToTable("Machines");
            modelBuilder.Entity<MachiningMachineEntity>().ToTable("MachiningMachines");
            modelBuilder.Entity<TechnologicalGroupEntity>().ToTable("TechnologicalGroups");
            modelBuilder.Entity<CrateEntity>().ToTable("Crates");
            modelBuilder.Entity<TechnologicalGroupCrateEntity>().ToTable("TechnologicalGroupCrates");
            modelBuilder.Entity<LocationMachineEntity>().ToTable("LocationMachines");
            modelBuilder.Entity<RegionalReportEntity>().ToTable("RegionalReports");
            modelBuilder.Entity<AttachmentEntity>().ToTable("Attachments");
            modelBuilder.Entity<CourseEntity>().ToTable("Courses");
            modelBuilder.Entity<IrregularCourseEntity>().ToTable("IrregularCourses");
            modelBuilder.Entity<RemainderEntity>().ToTable("Remainders");
            modelBuilder.Entity<KurzyPEEntity>().ToTable("KurzyPE");
            modelBuilder.Entity<ZatezAPEntity>().ToTable("ZatezAP");
            modelBuilder.Entity<CourseDelayReasonEntity>().ToTable("CourseDelayReasons");
            modelBuilder.Entity<TransporterEntity>().ToTable("Transporters");
            modelBuilder.Entity<StopEntity>().ToTable("Stops");
            modelBuilder.Entity<VehicleEntity>().ToTable("Vehicles");
            modelBuilder.Entity<TrailerEntity>().ToTable("Trailers");
        }
    }
}
