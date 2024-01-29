using Microsoft.EntityFrameworkCore;

namespace GreenTicket_WebAPI.Entities
{
    public class GreenTicketDbContext : DbContext
    {
        string _connectionString = "Server=BARTEKPC;Database=GreenTicketDB;Trusted_Connection=True;TrustServerCertificate=True";
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventPerformer> EventPerformers { get; set; }
        public DbSet<EventSubCategory> EventSubCategories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Restriction> Restrictions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<StandingPlace> StandingPlaces { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>(entity =>
            {
                entity
                .ToTable(nameof(Address));

                entity
                .Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(20);

                entity
                .Property(e => e.Street)
                .IsRequired()
                .HasMaxLength(50);

                entity
                .Property(e => e.StreetNo)
                .IsRequired()
                .HasMaxLength(10);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity
                .ToTable(nameof(City));

                entity
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity
                .ToTable(nameof(Country));

                entity
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            });

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
                .HasMaxLength(50);

                entity
                .Property(e => e.StartDateTime)
                .IsRequired()
                .HasPrecision(6);

                entity
                .Property(e => e.EndDateTime)
                .IsRequired()
                .HasPrecision(6);

                entity
                .Property(e => e.CreateDateTime)
                .IsRequired();

            });

            modelBuilder.Entity<EventCategory>(entity =>
            {
                entity
                .ToTable(nameof(EventCategory));

                entity
                .Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(30);
            });

            modelBuilder.Entity<EventSubCategory>(entity =>
            {
                entity
                .ToTable(nameof(EventSubCategory));

                entity
                .Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(30);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity
                .ToTable(nameof(Order));

                entity
                .ToTable(tb => tb.HasTrigger("SetOrderNoOnInsert"));

                entity
                .Property(e => e.UserId)
                .IsRequired();

                entity
                .Property(e => e.OrderDate)
                .IsRequired();

                entity
                .Property(e => e.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(19,4)");

                entity.Property(e => e.OrderNo)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity
                .ToTable(nameof(OrderStatus));

               entity
                .Property(e => e.Type)
                .HasConversion<int>();

                entity
                .Property(e => e.Date)
                .IsRequired();

                entity.
                Property(e => e.Reason).
                HasMaxLength(50);

                entity.
                Property(e => e.Comment).
                HasMaxLength(50);
            });

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

            modelBuilder.Entity<Image>(entity =>
            {
                entity
                .ToTable(nameof(Image));

                entity
               .Property(e => e.FileName)
               .IsRequired()
               .HasMaxLength(40);

                entity
                .Property(e => e.ImageType)
                .HasConversion<int>();

            });

            modelBuilder.Entity<Newsletter>(entity =>
            {
                entity
                .ToTable(nameof(Newsletter));

                entity
               .Property(e => e.EmailAddress)
               .IsRequired()
               .HasMaxLength(50);

                entity
               .Property(e => e.IPAddress)
               .IsRequired()
               .HasMaxLength(20);

                entity
                .Property(e => e.CreateDate)
                .HasColumnType("datetime2");

            });

            modelBuilder.Entity<Performer>(entity =>
            {
                entity
                .ToTable(nameof(Performer));

                entity
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity
                .ToTable(nameof(Payment));

                entity
                .Property(e => e.Date)
                .IsRequired();

                entity
                .Property(e => e.Direction)
                .IsRequired()
                .HasConversion<int>();

                entity
                .Property(e => e.Amount)
                .IsRequired()
                .HasColumnType("decimal(19,4)");

                entity
                .Property(e => e.PaymentMethod)
                .IsRequired()
                .HasConversion<int>();

                entity
                .Property(e => e.OrderId)
                .IsRequired();

                entity
                .Property(e => e.UserRecognitionDetail)
                .HasMaxLength(50);

                entity
                .Property(e => e.Comment)
                .HasMaxLength(100);

            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity
                .ToTable(nameof(Section));

                entity
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

                entity
                .Property(e => e.SectionType)
                .IsRequired();

                entity
                .Property(e => e.Capacity)
                .IsRequired();

                entity
                .Property(e => e.Price)
                .HasColumnType("decimal(19, 4)")
                .IsRequired();

            });

            modelBuilder.Entity<Restriction>(entity =>
            {
                entity
                .ToTable(nameof(Restriction));

                entity
                .Property(e => e.RestrictionType)
                .IsRequired();

                entity
                .Property(e => e.PriceReduction)
                .IsRequired()
                .HasColumnType("decimal(19,4)");

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable(nameof(Role));

                entity
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            });

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


            });

            modelBuilder.Entity<StandingPlace>(entity =>
            {
                entity
                .ToTable(nameof(StandingPlace));
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity
                .ToTable(nameof(Ticket));

                entity
                .Property(e => e.QrCode)
                .IsRequired();

                entity
                .Property(e => e.OrderID)
                .IsRequired();

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity
                .ToTable(nameof(User));

                entity
                .Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50);

                entity
                .Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(150);

                entity
                .Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

                entity
                .Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

                entity
                .Property(e => e.DateOfBirth)
                .IsRequired()
                .HasColumnType("date");

            });

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
