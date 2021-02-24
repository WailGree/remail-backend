using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Remail_backend.Models;
using RemailCore.Models;
using RemailCore.Services;

namespace Remail_backend.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : Controller
    {
        private AccountContext _context;

        public ApiController(AccountContext context)
        {
            _context = context;
            _context.Account = new Account();
            _context.MailService = new MailService();
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost("getMails")]
        public List<Email> GetMails()
        {
            //string username = _context.Account.Username;
            //string password = _context.Account.Password;
            string username = "tom1.wales2@gmail.com";
            string password = "Almafa1234";
            if (_context.MailService.IsCorrectLoginCredentials(username, password))
            {
                List<Email> emails = _context.MailService.GetMails("tom1.wales2@gmail.com", "Almafa1234");
                return emails;
            }

            return null;
        }
    }
}