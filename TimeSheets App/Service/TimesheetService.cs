using TimeSheets_App.Model;
using TimeSheets_App.Repository;
using TimeSheets_App.Service.TimeSheets_App.Services;

namespace TimeSheets_App.Service
{
    public class TimesheetService : ITimesheetService
    {
        private readonly ITimesheetRepository _timesheetRepository;

        public TimesheetService(ITimesheetRepository timesheetRepository)
        {
            _timesheetRepository = timesheetRepository;
        }

        public async Task<List<Timesheet>> GetAllTimesheetsAsync()
        {
            return await _timesheetRepository.GetAllTimesheetsAsync();
        }

        public async Task<Timesheet> GetTimesheetByIdAsync(int id)
        {
            return await _timesheetRepository.GetTimesheetByIdAsync(id);
        }

        public async Task AddTimesheetAsync(Timesheet timesheet)
        {
            if(timesheet.OnLeave == true)
            {
                timesheet.Activities = null;
            }
            await _timesheetRepository.AddTimesheetAsync(timesheet);
        }
        public async Task UpdateActivityAsync(int timesheetId, int activityId, Activity updatedActivity)
        {
            await _timesheetRepository.UpdateActivityAsync(timesheetId, activityId, updatedActivity);
        }
        public async Task DeleteTimesheetAsync(int id,int activityId)
        {
            await _timesheetRepository.DeleteTimesheetAsync(id, activityId);
        }
    }
}
