using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remail_backend.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }
        [HttpPost("api/getmails")]
        public async Task<IActionResult> GetMails()
        {

            return Ok();
        }
    }
}