using WebAlpha.Models;
using System.Threading.Tasks;

namespace WebAlpha.Data.Repositories
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<ApplicationUser> UpdateUserAsync(ApplicationUser user);
    }
}