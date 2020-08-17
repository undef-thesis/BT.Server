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

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne<RefreshToken>(x => x.RefreshToken)
                .WithOne(x => x.User)
                .HasForeignKey<RefreshToken>(x => x.UserId);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}