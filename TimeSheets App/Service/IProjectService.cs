using TimeSheets_App.Model;

namespace TimeSheets_App.Service
{
    public interface IProjectService
    {
        public IEnumerable<Project> GetAllProjects();

        public void PostProject(Project project);
    }
}
