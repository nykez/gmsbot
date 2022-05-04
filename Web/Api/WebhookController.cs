using Microsoft.AspNetCore.Mvc;
using Web.Extensions;
using Everyday.GmodStore.Sdk.Model;


namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        // GET: api/<WebhookController>
        [HttpPost("revoked")]
        [RestrictDomain("gmodstore.com", "localhost")]
        public async Task<IActionResult> Revoked([FromBody] ProductPurchase addon)
        {
            if (!addon.Revoked)
                return BadRequest("Calling revoked API while addon is not revoked.");

            return Ok("ok");
        }

        [HttpPost("purchase")]
        [RestrictDomain("gmodstore.com", "localhost")]
        public async Task<IActionResult> Purchase([FromBody] ProductPurchase addon)
        {
            return Ok("ok");
        }

        [HttpPost("unrevoked")]
        [RestrictDomain("gmodstore.com", "localhost")]
        public async Task<IActionResult> Unrevoked([FromBody] ProductPurchase addon)
        {
            if (addon.Revoked)
                return BadRequest("Calling unrevoked API while addon is revoked.");

            return Ok("ok");
        }

    }
}
