using Microsoft.AspNetCore.Mvc;
using TicketHub.Api.Models;
using TicketHub.Api.Services;

namespace TicketHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly QueueService _queueService;

        public PurchaseController(QueueService queueService)
        {
            _queueService = queueService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PurchaseRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _queueService.SendMessageAsync(request);

            return Ok(new { message = "Purchase is valid and sent to Azure Queue." });
        }
    }
}
