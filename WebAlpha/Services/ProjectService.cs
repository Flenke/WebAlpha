using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAlpha.Data.Repositories;
using WebAlpha.Models;
using WebAlpha.Models.ViewModels;

namespace WebAlpha.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;

        public ProjectService(IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAllProjectsAsync()
        {
            var projects = await _projectRepository.GetAllProjectsAsync();
            return projects.Select(MapToViewModel);
        }

        public async Task<IEnumerable<ProjectViewModel>> GetProjectsByStatusAsync(ProjectStatus status)
        {
            var projects = await _projectRepository.GetProjectsByStatusAsync(status);
            return projects.Select(MapToViewModel);
        }

        public async Task<IEnumerable<ProjectViewModel>> GetProjectsByUserIdAsync(string userId)
        {
            var projects = await _projectRepository.GetProjectsByUserIdAsync(userId);
            return projects.Select(MapToViewModel);
        }

        public async Task<ProjectViewModel> GetProjectByIdAsync(int id)
        {
            var project = await _projectRepository.GetProjectByIdAsync(id);
            return project != null ? MapToViewModel(project) : null;
        }

        public async Task<ProjectViewModel> CreateProjectAsync(ProjectCreateViewModel model, string userId)
        {
            var project = new Project
            {
                Name = model.Name,
                Description = model.Description,
                ClientName = model.ClientName,
                Budget = model.Budget,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Status = model.Status,
                UserId = userId
            };

            var createdProject = await _projectRepository.CreateProjectAsync(project);
            return MapToViewModel(createdProject);
        }

        public async Task<ProjectViewModel> UpdateProjectAsync(ProjectUpdateViewModel model)
        {
            var project = await _projectRepository.GetProjectByIdAsync(model.Id);
            if (project == null)
            {
                return null;
            }

            project.Name = model.Name;
            project.Description = model.Description;
            project.ClientName = model.ClientName;
            project.Budget = model.Budget;
            project.StartDate = model.StartDate;
            project.EndDate = model.EndDate;
            project.Status = model.Status;

            var updatedProject = await _projectRepository.UpdateProjectAsync(project);
            return MapToViewModel(updatedProject);
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            return await _projectRepository.DeleteProjectAsync(id);
        }

        public async Task<DashboardViewModel> GetDashboardDataAsync(string userId)
        {
            var allProjects = await _projectRepository.GetProjectsCountAsync();
            var inProgressProjects = await _projectRepository.GetProjectsCountByStatusAsync(ProjectStatus.InProgress);
            var completedProjects = await _projectRepository.GetProjectsCountByStatusAsync(ProjectStatus.Completed);
            var totalBudget = await _projectRepository.GetTotalBudgetAsync();

            // Hämta de senaste projekten för användaren
            var userProjects = await _projectRepository.GetProjectsByUserIdAsync(userId);
            var recentProjects = userProjects
                .OrderByDescending(p => p.StartDate)
                .Take(5)
                .Select(MapToViewModel)
                .ToList();

            return new DashboardViewModel
            {
                TotalProjects = allProjects,
                InProgressProjects = inProgressProjects,
                CompletedProjects = completedProjects,
                TotalBudget = totalBudget,
                RecentProjects = recentProjects
            };
        }

        private ProjectViewModel MapToViewModel(Project project)
        {
            return new ProjectViewModel
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                ClientName = project.ClientName,
                Budget = project.Budget,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Status = project.Status
            };
        }
    }
}