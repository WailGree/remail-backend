using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RemailCore.Services;

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

        [HttpPost("send-email")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> SendMail([FromForm] string body, [FromForm] string subject, [FromForm] string to)
        {
            if (!string.IsNullOrEmpty(to))
            {
                MailService mailService = new MailService();
                mailService.SendNewEmail("tom1.wales2@gmail.com", "Almafa1234", body, subject, to);  // get username and password from context !
                return Ok("Email sent");
            }

            return BadRequest();
        }
    }
}