﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("login")]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult Login([FromForm] string username, [FromForm] string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                _context.Account.Username = username;
                _context.Account.Password = password;
                if (_context.MailService.IsCorrectLoginCredentials(username, password))
                {
                    return Ok("Success");
                }
            }

            return BadRequest();
        }

        [HttpPost("getMails")]
        public List<Email> GetMails()
        {
            string username = _context.Account.Username;
            string password = _context.Account.Password;
            if (_context.MailService.IsCorrectLoginCredentials(username, password))
            {
                return _context.MailService.GetMails(username, password);
            }

            return null;
        }
    }
}