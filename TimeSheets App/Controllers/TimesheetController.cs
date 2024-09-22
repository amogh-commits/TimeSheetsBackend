using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeSheets_App.Data;
using TimeSheets_App.Model;
using TimeSheets_App.Repository;
using TimeSheets_App.Service;
using TimeSheets_App.Service.TimeSheets_App.Services;

namespace TimeSheets_App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class TimesheetController : ControllerBase
    {
        private readonly ITimesheetRepository _repository;
        private readonly TimesheetDbContext _context;
        private readonly ITimesheetService _service;

        public TimesheetController(ITimesheetRepository repository,TimesheetDbContext context,ITimesheetService service)
        {
            _repository = repository;
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTimesheets()
        {
            var timesheets = await _repository.GetAllTimesheetsAsync();
            return Ok(timesheets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTimesheet(int id)
        {
            var timesheet = await _repository.GetTimesheetByIdAsync(id);
            if (timesheet == null) return NotFound();
            return Ok(timesheet);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateTimesheet([FromBody] Timesheet timesheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            _context.Timesheets.Add(timesheet);

            if (timesheet.Activities != null)
            {
                foreach (var activity in timesheet.Activities)
                {
                    _context.Activities.Add(activity);
                }
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{timesheetId}/activities/{activityId}")]
        public async Task<IActionResult> UpdateActivity(int timesheetId, int activityId, [FromBody] Activity updatedActivity)
        {
            await _service.UpdateActivityAsync(timesheetId, activityId, updatedActivity);
            return Ok("Activity updated successfully");
        }



        [HttpDelete("{id}/{activityId}")]
        public async Task<IActionResult> DeleteTimesheet(int id, int activityId)
        {
            await _repository.DeleteTimesheetAsync(id,activityId);
            return NoContent();
        }
    }
}
