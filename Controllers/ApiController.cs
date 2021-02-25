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

        // POST: api/Login
        //[HttpPost("Login")]
        //public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        //{
        //    _context.TodoItems.Add(todoItem);
        //    await _context.SaveChangesAsync();

        //    //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        //    return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        //}

        [HttpPost("login")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> Login([FromForm] string username, [FromForm] string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                _context.Account.Username = username;
                _context.Account.Password = password;
                return Ok("Success");
            }

            return BadRequest();
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
                List<Email> emails = _context.MailService.GetMails(username, password);
                return emails;
            }

            return null;
        }
    }
}