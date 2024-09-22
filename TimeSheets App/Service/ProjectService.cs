using TimeSheets_App.Model;
using TimeSheets_App.Repository;

namespace TimeSheets_App.Service
{
    public class ProjectService:IProjectService
    {
        private readonly IRepository<Project> _repository;

        public ProjectService(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            var project = _repository.GetAll();
            if (project == null)
            {
                throw new Exception($"Project not found.");
            }

            return project;
        }

        public void PostProject(Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project), "Project cannot be null.");
            }

            _repository.Add(project);
            _repository.Save();
        }
    }
}
