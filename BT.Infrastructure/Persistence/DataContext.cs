using System;
using System.Text;
using System.Threading.Tasks;
using BT.Application.Common;
using BT.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace BT.Infrastructure.Persistence
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<UserMeeting> UserMeeting { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Avatar> Avatar { get; set; }
        public DbSet<MeetingImage> MeetingImages { get; set; }
        public DbSet<City> Cities { get; set; }

        public DataContext()
        {
            // dotnet ef migrations add init
            // dotnet ef database update
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseMySql("Server=pl2.sohost.pl;Port=3306;Database=so1056_bt;Uid=so1056_bt;Pwd=vehnu9-Hijmib-sutquk;");
                optionsBuilder.UseNpgsql("Host=app-2fc35c64-442f-406b-b2db-9ed58ea7253c-do-user-7336880-0.b.db.ondigitalocean.com;Port=25060;Database=db;Username=db;Password=e3fs6peuckz8rr9h;SslMode=Require;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(x => x.RefreshToken)
                .WithOne(x => x.User)
                .HasForeignKey<RefreshToken>(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<User>()
                .HasOne(x => x.Avatar)
                .WithOne(x => x.User)
                .HasForeignKey<Avatar>(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<User>()
                .HasMany(x => x.OrganizedMeetings)
                .WithOne(x => x.MeetingOrganizer)
                .HasForeignKey(x => x.MeetingOrganizerId);

            builder.Entity<User>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.Entity<UserMeeting>()
                .HasKey(x => new { x.UserId, x.MeetingId });
            builder.Entity<UserMeeting>()
                .HasOne(x => x.User)
                .WithMany(x => x.EnrolledMeetings)
                .HasForeignKey(x => x.UserId);
            builder.Entity<UserMeeting>()
                .HasOne(x => x.Meeting)
                .WithMany(x => x.Participants)
                .HasForeignKey(x => x.MeetingId);

            builder.Entity<Meeting>()
                .HasOne<Address>(x => x.Address)
                .WithOne(x => x.Meeting)
                .HasForeignKey<Address>(x => x.MeetingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Meeting>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Meeting)
                .HasForeignKey(x => x.MeetingId);

            builder.Entity<Meeting>()
                .HasMany(x => x.Images)
                .WithOne(x => x.Meeting)
                .HasForeignKey(x => x.MeetingId);

            builder.Entity<Category>()
                .HasMany(x => x.Meetings)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            builder.Seed();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}