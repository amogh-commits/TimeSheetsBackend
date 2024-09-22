using TimeSheets_App.Model;

namespace TimeSheets_App.Service
{
    public interface ISubProjectService
    {
        public IEnumerable<SubProject> GetAllSubProjects();

        public void PostSubProject(SubProject subProject);
    }
}
