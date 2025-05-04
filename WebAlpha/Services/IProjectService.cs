using System.Collections.Generic;
using System.Threading.Tasks;
using WebAlpha.Models;
using WebAlpha.Models.ViewModels;

namespace WebAlpha.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectViewModel>> GetAllProjectsAsync();
        Task<IEnumerable<ProjectViewModel>> GetProjectsByStatusAsync(ProjectStatus status);
        Task<IEnumerable<ProjectViewModel>> GetProjectsByUserIdAsync(string userId);
        Task<ProjectViewModel> GetProjectByIdAsync(int id);
        Task<ProjectViewModel> CreateProjectAsync(ProjectCreateViewModel model, string userId);
        Task<ProjectViewModel> UpdateProjectAsync(ProjectUpdateViewModel model);
        Task<bool> DeleteProjectAsync(int id);
        Task<DashboardViewModel> GetDashboardDataAsync(string userId);
    }
}