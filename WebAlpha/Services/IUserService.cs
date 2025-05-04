using WebAlpha.Models;
using System.Threading.Tasks;

namespace WebAlpha.Services
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<ApplicationUser> UpdateUserProfileAsync(string userId, string firstName, string lastName, string profileImageUrl);
    }
}