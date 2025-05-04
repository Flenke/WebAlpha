using System;
using System.ComponentModel.DataAnnotations;

namespace WebAlpha.Models.ViewModels
{
    public class ProjectCreateViewModel
    {
        [Required(ErrorMessage = "Projektnamn krävs")]
        [StringLength(100, ErrorMessage = "Projektnamnet får inte vara längre än 100 tecken")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Beskrivning krävs")]
        [StringLength(500, ErrorMessage = "Beskrivningen får inte vara längre än 500 tecken")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Klientnamn krävs")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Budget krävs")]
        [DataType(DataType.Currency)]
        public decimal Budget { get; set; }

        [Required(ErrorMessage = "Startdatum krävs")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public ProjectStatus Status { get; set; }
    }
}