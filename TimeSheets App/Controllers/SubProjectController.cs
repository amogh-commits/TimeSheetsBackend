using Microsoft.AspNetCore.Mvc;
using TimeSheets_App.Model;
using TimeSheets_App.Service;
using System.Collections.Generic;

namespace TimeSheets_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubProjectController : ControllerBase
    {
        private readonly ISubProjectService _subProjectService;

        public SubProjectController(ISubProjectService subProjectService)
        {
            _subProjectService = subProjectService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubProject>> GetSubProjects()
        {
            var subProjects = _subProjectService.GetAllSubProjects();
            return Ok(subProjects);
        }

        [HttpPost]
        public IActionResult PostSubProject([FromBody] SubProject subProject)
        {
            if (subProject == null)
            {
                return BadRequest("SubProject is null.");
            }

            _subProjectService.PostSubProject(subProject);

            return CreatedAtAction(nameof(GetSubProjects), new { id = subProject.Id }, subProject);
        }
    }
}
