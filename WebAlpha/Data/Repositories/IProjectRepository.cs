using WebAlpha.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAlpha.Data.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<IEnumerable<Project>> GetProjectsByStatusAsync(ProjectStatus status);
        Task<IEnumerable<Project>> GetProjectsByUserIdAsync(string userId);
        Task<Project> GetProjectByIdAsync(int id);
        Task<Project> CreateProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(Project project);
        Task<bool> DeleteProjectAsync(int id);
        Task<int> GetProjectsCountAsync();
        Task<int> GetProjectsCountByStatusAsync(ProjectStatus status);
        Task<decimal> GetTotalBudgetAsync();
    }
}