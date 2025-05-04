using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WebAlpha.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfileImageUrl { get; set; }  // Notera frågetecknet som gör den nullable

        // Navigation property för användarens projekt
        public ICollection<Project>? Projects { get; set; }
    }
}