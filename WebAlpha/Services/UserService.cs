using WebAlpha.Data.Repositories;
using WebAlpha.Models;
using System.Threading.Tasks;

namespace WebAlpha.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<ApplicationUser> UpdateUserProfileAsync(string userId, string firstName, string lastName, string profileImageUrl)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return null;
            }

            user.FirstName = firstName;
            user.LastName = lastName;
            user.ProfileImageUrl = profileImageUrl;

            return await _userRepository.UpdateUserAsync(user);
        }
    }
}