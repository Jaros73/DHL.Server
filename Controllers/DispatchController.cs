using Microsoft.AspNetCore.Mvc;
using DHL.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using DHL.Server.Services;

namespace DHL.Server.Controllers
{
    [ApiController]
    [Route("api/dispatch")]
    public class DispatchController : ControllerBase
    {
        private readonly DispatchService _dispatchService;

        public DispatchController(DispatchService dispatchService)
        {
            _dispatchService = dispatchService;
        }

        /// <summary>
        /// Vrátí všechny dispečerské záznamy.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<DispatchModel>>> GetDispatches()
        {
            var dispatches = await _dispatchService.GetDispatchesAsync();

            if (dispatches == null)
            {
                return NotFound();
            }

            return Ok(dispatches);
        }

        /// <summary>
        /// Vrátí dispečerský záznam podle ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<DispatchModel>> GetDispatch(int id)
        {
            var dispatch = await _dispatchService.GetDispatchByIdAsync(id);
            if (dispatch == null)
                return NotFound();

            return Ok(dispatch);
        }

        /// <summary>
        /// Filtrování záznamů podle kritérií.
        /// </summary>
        [HttpPost("filter")]
        public async Task<ActionResult<List<DispatchModel>>> GetFilteredDispatches([FromBody] DispatchFilter filter)
        {
            var dispatches = await _dispatchService.GetFilteredDispatchesAsync(filter);
            return Ok(dispatches);
        }

        /// <summary>
        /// Smazání záznamu podle ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDispatch(int id)
        {
            await _dispatchService.DeleteDispatchAsync(id);
            return NoContent();
        }
    }
}
