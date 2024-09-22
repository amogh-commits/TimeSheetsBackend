using TimeSheets_App.Model;

namespace TimeSheets_App.Repository
{
    public interface ITimesheetRepository
    {
        Task<List<Timesheet>> GetAllTimesheetsAsync();
        Task<Timesheet> GetTimesheetByIdAsync(int id);
        Task AddTimesheetAsync(Timesheet timesheet);
        Task DeleteTimesheetAsync(int id,int activityId);
        Task UpdateActivityAsync(int timesheetId, int activityId, Activity updatedActivity);
    }
}
