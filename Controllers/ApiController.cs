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

        [HttpPost("getMails")]
        public async Task<IActionResult> GetMails()
        {
            throw new NotImplementedException();
        }
    }
}