using Microsoft.AspNetCore.Mvc;
using DHL.Server.Models;
using DHL.Server.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using DHL.Server.Services;

namespace DHL.Server.Controllers
{
    [Route("api/dispatch")]
    [ApiController]
    public class DispatchController : ControllerBase
    {
        private readonly IDispatchService _dispatchService;

        public DispatchController(IDispatchService dispatchService)
        {
            _dispatchService = dispatchService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DispatchModel>>> GetDispatches()
        {
            var dispatches = await _dispatchService.GetDispatchesAsync();
            return dispatches ?? new List<DispatchModel>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DispatchModel>> GetDispatch(int id)
        {
            var dispatch = await _dispatchService.GetDispatchByIdAsync(id);
            if (dispatch == null)
                return NotFound();

            return Ok(dispatch);
        }

        [HttpPost("filter")]
        public async Task<ActionResult<List<DispatchModel>>> GetFilteredDispatches([FromBody] DispatchFilter filter)
        {
            var dispatches = await _dispatchService.GetFilteredDispatchesAsync(filter);
            return Ok(dispatches);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDispatch(int id)
        {
            await _dispatchService.DeleteDispatchAsync(id);
            return NoContent();
        }
    }
}
