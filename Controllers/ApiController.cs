﻿using Microsoft.AspNetCore.Mvc;
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

        // POST: api/Login
        //[HttpPost("Login")]
        //public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        //{
        //    _context.TodoItems.Add(todoItem);
        //    await _context.SaveChangesAsync();

        //    //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        //    return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        //}
    }
}