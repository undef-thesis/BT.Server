using System.Threading.Tasks;
using BT.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace BT.Application.Common
{
    public interface IDataContext
    {
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync();
    }
}