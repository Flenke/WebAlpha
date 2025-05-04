using WebAlpha.Models;
using WebAlpha.Models.ViewModels;
using WebAlpha.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAlpha.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectController(IProjectService projectService, UserManager<ApplicationUser> userManager)
        {
            _projectService = projectService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string status = null)
        {
            if (string.IsNullOrEmpty(status))
            {
                var projects = await _projectService.GetAllProjectsAsync();
                ViewBag.CurrentFilter = "All";
                return View(projects);
            }
            else
            {
                if (status == "InProgress")
                {
                    var projects = await _projectService.GetProjectsByStatusAsync(ProjectStatus.InProgress);
                    ViewBag.CurrentFilter = "InProgress";
                    return View(projects);
                }
                else if (status == "Completed")
                {
                    var projects = await _projectService.GetProjectsByStatusAsync(ProjectStatus.Completed);
                    ViewBag.CurrentFilter = "Completed";
                    return View(projects);
                }
                else
                {
                    var projects = await _projectService.GetAllProjectsAsync();
                    ViewBag.CurrentFilter = "All";
                    return View(projects);
                }
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                await _projectService.CreateProjectAsync(model, userId);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            var model = new ProjectUpdateViewModel
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

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProjectUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _projectService.UpdateProjectAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _projectService.DeleteProjectAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}