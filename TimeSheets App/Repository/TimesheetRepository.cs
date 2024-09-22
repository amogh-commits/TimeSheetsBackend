using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TimeSheets_App.Data;
using TimeSheets_App.Model;

namespace TimeSheets_App.Repository
{
    public class TimesheetRepository : ITimesheetRepository
    {
        private readonly TimesheetDbContext _context;

        public TimesheetRepository(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<List<Timesheet>> GetAllTimesheetsAsync()
        {
            return await _context.Timesheets.Include(t => t.Activities).ToListAsync();
        }

        public async Task<Timesheet> GetTimesheetByIdAsync(int id)
        {
            return await _context.Timesheets.Include(t => t.Activities)
                                             .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddTimesheetAsync(Timesheet timesheet)
        {
            if (timesheet.OnLeave == true)
            {
                timesheet.Activities = null;
            }
            await _context.Timesheets.AddAsync(timesheet);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateActivityAsync(int timesheetId, int activityId, Model.Activity updatedActivity)
        {
            var timesheet = await _context.Timesheets.Include(t => t.Activities)
                                                     .FirstOrDefaultAsync(t => t.Id == timesheetId);
            if (timesheet == null)
            {
                throw new Exception("Timesheet not found.");
            }

            var activity = timesheet.Activities.FirstOrDefault(a => a.Id == activityId);
            if (activity == null)
            {
                throw new Exception("Activity not found.");
            }

            activity.Project = updatedActivity.Project;
            activity.SubProject = updatedActivity.SubProject;
            activity.Batch = updatedActivity.Batch;
            activity.HoursNeeded = updatedActivity.HoursNeeded;
            activity.Description = updatedActivity.Description;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTimesheetAsync(int id, int activityId)
        {
            var timesheet = await _context.Timesheets
                .Include(t => t.Activities) 
                .FirstOrDefaultAsync(t => t.Id == id);

            if (timesheet == null)
            {
                throw new Exception("Timesheet not found");
            }

            var activity = timesheet.Activities.FirstOrDefault(a => a.Id == activityId);

            if (activity == null)
            {
                throw new Exception("Activity not found");
            }

            if (timesheet.Activities.Count == 1)
            {
                _context.Activities.Remove(activity);
                _context.Timesheets.Remove(timesheet);
            }
            else
            {
                _context.Activities.Remove(activity);
            }

            await _context.SaveChangesAsync();
        }

    }
}
