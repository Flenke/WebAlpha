using System.Collections.Generic;

namespace WebAlpha.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalProjects { get; set; }
        public int InProgressProjects { get; set; }
        public int CompletedProjects { get; set; }
        public decimal TotalBudget { get; set; }
        public List<ProjectViewModel> RecentProjects { get; set; }
    }
}