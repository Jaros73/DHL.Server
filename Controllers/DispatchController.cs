using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DHL.Server.Features.Dispatching.Services;
using DHL.Server.Models.DTO;
using DHL.Server.Models.Entities;
using DHL.Server.Data;
using DHL.Server.Features.Dispatching.Interfaces;



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
        public async Task<ActionResult<List<DispatchModelEntity>>> GetDispatches()
        {
            var dispatches = await _dispatchService.GetDispatchesAsync();
            return dispatches ?? new List<DispatchModelEntity>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DispatchModelEntity>> GetDispatch(int id)
        {
            var dispatch = await _dispatchService.GetDispatchByIdAsync(id);
            if (dispatch == null)
                return NotFound();

            return Ok(dispatch);
        }

        [HttpPost("filter")]
        public async Task<ActionResult<List<DispatchModelEntity>>> GetFilteredDispatches([FromBody] DispatchFilter filter)
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
