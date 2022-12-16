using Microsoft.EntityFrameworkCore;

namespace GreenTicket_WebAPI.Entities
{
    public class GreenTicketDbContext : DbContext
    {
        string _connectionString = "Server=DESKTOP-12S11S9\\SQLEXPRESS;Database=GreenTicketDB;Trusted_Connection=True;TrustServerCertificate=True";
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventSubCategory> EventSubCategories { get; set; }
        public DbSet<Performer> Performers { get; set; }

        public DbSet<EventPerformer> EventPerformers { get; set; }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<Seat> Seats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Address
            modelBuilder.Entity<Address>(entity =>
            {
                entity
                .ToTable(nameof(Address));

                entity
                .Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(50);

                entity
                .Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(20);

                entity
                .Property(e => e.City)
                .IsRequired()
                .HasMaxLength(50);

                entity
                .Property(e => e.Street)
                .IsRequired()
                .HasMaxLength(50);

                entity
                .Property(e => e.StreetNo)
                .IsRequired()
                .HasMaxLength(10);
            });

            // Event
            modelBuilder.Entity<Event>(entity =>
            {
                entity
                .ToTable(nameof(Event));

                entity
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

                entity
                .Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(300);

                entity
                .Property(e => e.StartDateTime)
                .IsRequired()
                .HasPrecision(6);

                entity
                .Property(e => e.EndDateTime)
                .IsRequired()
                .HasPrecision(6);
            });

            // EventCategory
            modelBuilder.Entity<EventCategory>(entity =>
            {
                entity
                .ToTable(nameof(EventCategory));

                entity
                .Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(30);
            });

            // EventSubCategory
            modelBuilder.Entity<EventSubCategory>(entity =>
            {
                entity
                .ToTable(nameof(EventSubCategory));

                entity
                .Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(30);
            });

            // EventPerformer
            modelBuilder.Entity<EventPerformer>(entity =>
            {
                entity
                .ToTable(nameof(EventPerformer));

                entity
                .HasKey(bc => new { bc.EventId, bc.PerformerId });

                entity.HasOne(bc => bc.Event)
                .WithMany(b => b.EventPerformers)
                .HasForeignKey(bc => bc.EventId);

                entity.HasOne(bc => bc.Performer)
                .WithMany(c => c.EventPerformers)
                .HasForeignKey(bc => bc.PerformerId);
            });

            //Performer
            modelBuilder.Entity<Performer>(entity =>
            {
                entity
                .ToTable(nameof(Performer));

                entity
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            });

            // Section
            modelBuilder.Entity<Section>(entity =>
            {
                entity
                .ToTable(nameof(Section));

                entity
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

                entity
                .Property(e => e.Capacity)
                .IsRequired();

                entity
                .Property(e => e.Price)
                .HasColumnType("decimal(19, 4)")
                .IsRequired();

            });

            // Row
            modelBuilder.Entity<Row>(entity =>
            {
                entity
                .ToTable(nameof(Row));

                entity
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

                entity
                .Property(e => e.SectionId)
                .IsRequired();
            });

            // Seat
            modelBuilder.Entity<Seat>(entity =>
            {
                entity
                .ToTable(nameof(Seat));

                entity
                .Property(e => e.Number)
                .IsRequired();

                entity
                .Property(e => e.RowId)
                .IsRequired();

                entity
                .Property(e => e.CustomPrice)
                .HasColumnType("decimal(19, 4)");
            });

            // Venue
            modelBuilder.Entity<Venue>(entity =>
            {
                entity
                .ToTable(nameof(Venue));

                entity
               .Property(e => e.Name)
               .IsRequired()
               .HasMaxLength(100);

                entity
                .Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
