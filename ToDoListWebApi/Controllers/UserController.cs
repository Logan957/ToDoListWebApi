﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListWebApi.DataBase;
using ToDoListWebApi.Models.Users;

namespace ToDoListWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _db;

        public UserController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            _db.Users.Add(new User { Login = "Tom" });
            _db.Users.Add(new User { Login = "Alice" });
            _db.SaveChanges();

            return await _db.Users.ToListAsync();
        }
    }
}
