using System;
using System.ComponentModel.DataAnnotations;
using WebAlpha.Models;

namespace WebAlpha.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public string ClientName { get; set; }

        [DataType(DataType.Currency)]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public ProjectStatus Status { get; set; }

        // För att koppla ett projekt till en användare
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}