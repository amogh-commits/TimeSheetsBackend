using TimeSheets_App.Model;
using TimeSheets_App.Repository;

namespace TimeSheets_App.Service
{
    public class SubProjectService : ISubProjectService
    {
        private readonly IRepository<SubProject> _repository;

        public SubProjectService(IRepository<SubProject> repository)
        {
            _repository = repository;
        }

        public IEnumerable<SubProject> GetAllSubProjects()
        {
            var subProject = _repository.GetAll();
            if (subProject == null)
            {
                throw new Exception($"SubProject not found.");
            }

            return subProject;
        }

        public void PostSubProject(SubProject subProject)
        {
            if (subProject == null)
            {
                throw new ArgumentNullException(nameof(subProject), "SubProject cannot be null.");
            }

            _repository.Add(subProject);
            _repository.Save();
        }
    }
}
