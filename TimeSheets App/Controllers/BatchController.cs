using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheets_App.Model;
using TimeSheets_App.Service;

namespace TimeSheets_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatchService _batchService;

        public BatchController(IBatchService batchService)
        {
            _batchService = batchService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Batch>> GetBatches()
        {
            return Ok(_batchService.GetAllBatches());
        }

        [HttpPost]
        public IActionResult PostBatch([FromBody] Batch batch)
        {
            if (batch == null)
            {
                return BadRequest("Batch is null.");
            }

            _batchService.PostBatch(batch);
            return CreatedAtAction(nameof(GetBatches), new { id = batch.Id }, batch);
        }
    }
}
