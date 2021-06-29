using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using To_Do.Controllers;
using To_Do.Data;
using To_Do.Entity;

namespace To_Do.Controllers
{
   
    public class UserController : BaseApiController
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("users")]
        public ActionResult<IEnumerable<AppUser>> GetUser()
        {
            return _context.Users.ToList();
        }
        [HttpGet("users/{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            return _context.Users.Find(id);
        }

    }

}
