using TimeSheets_App.Model;

namespace TimeSheets_App.Service
{
    public interface IBatchService
    {
        public IEnumerable<Batch> GetAllBatches();

        public void PostBatch(Batch batch);
       
    }
}
