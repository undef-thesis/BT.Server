using System.Threading.Tasks;
using BT.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Common
{
    public interface IDataContext
    {
        DbSet<User> Users { get; set; }
        DbSet<RefreshToken> RefreshToken { get; set; }
        DbSet<Meeting> Meetings { get; set; }
        DbSet<UserMeeting> UserMeeting { get; set; }
        DbSet<Address> Address { get; set; }
        Task<int> SaveChangesAsync();
    }
}