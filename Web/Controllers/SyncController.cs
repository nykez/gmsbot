using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class SyncController : Controller
    {
        public SyncController()
        {

        }
        public IActionResult Index()
        {
            return Ok("Index");
        }

        [HttpGet("sync/{id}")]
        public IActionResult Sync(Guid id)
        {
            return NotFound();
        }
    }
}
