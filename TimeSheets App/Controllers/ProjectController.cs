using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheets_App.Model;
using TimeSheets_App.Service;

namespace TimeSheets_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Project>> GetProjects()
        {
            return Ok(_projectService.GetAllProjects());
        }

        [HttpPost]
        public IActionResult PostProject([FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest("Project is null.");
            }

            _projectService.PostProject(project);
            return CreatedAtAction(nameof(GetProjects), new { id = project.Id }, project);
        }
    }
}
