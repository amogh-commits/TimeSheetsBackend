using TimeSheets_App.Model;
using TimeSheets_App.Repository;

namespace TimeSheets_App.Service
{
    public class BatchService : IBatchService
    {
        private readonly IRepository<Batch> _repository;

        public BatchService(IRepository<Batch> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Batch> GetAllBatches()
        {
            var batch = _repository.GetAll();
            if (batch == null)
            {
                throw new Exception($"Batch not found.");
            }

            return batch;
        }

        public void PostBatch(Batch batch)
        {
            if (batch == null)
            {
                throw new ArgumentNullException(nameof(batch), "Batch cannot be null.");
            }

            _repository.Add(batch);
            _repository.Save();
        }
    }
}
