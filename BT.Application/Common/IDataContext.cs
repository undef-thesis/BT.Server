using System.Threading.Tasks;
using BT.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Common
{
    public interface IDataContext
    {
        DbSet<User> Users { get; set; }
        DbSet<RefreshToken> RefreshToken { get; set; }
        Task<int> SaveChangesAsync();
    }
}