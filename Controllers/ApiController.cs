using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RemailCore.Models;
using RemailCore.Services;

namespace Remail_backend.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : Controller
    {
        MailService _mailService = new MailService();

        public ApiController()
        {
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost("login")]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult Login([FromForm] string username, [FromForm] string password)
        {
            switch (string.IsNullOrEmpty(username))
            {
                case false when !string.IsNullOrEmpty(password) &&
                                _mailService.IsCorrectLoginCredentials(username, password):
                    return Ok("Success");
                default:
                    return BadRequest();
            }
        }

        [HttpPost("log-out")]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult LogOut()
        {
            return Ok("Success");
        }

        [HttpPost("get-mails")]
        public IEnumerable<Email> GetMails()
        {
            string username = "tom1.wales2@gmail.com";
            string password = "Almafa1234";

            if (_mailService.IsCorrectLoginCredentials(username, password))
            {
                return _mailService.GetMails(username, password);
            }

            return null;
        }

        [HttpPost("send-email")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> SendMail([FromForm] string body, [FromForm] string subject,
            [FromForm] string to)
        {
            string username = "tom1.wales2@gmail.com";
            string password = "Almafa1234";

            switch (string.IsNullOrEmpty(to))
            {
                case false when _mailService.IsCorrectLoginCredentials(username, password):

                    body = body == null ? string.Empty : body;
                    subject = subject == null ? string.Empty : subject;

                    _mailService.SendNewEmail(username, password, body, subject, to);
                    return Ok("Email sent");
                default:
                    return BadRequest();
            }
        }
    }
}