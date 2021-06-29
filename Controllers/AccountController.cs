using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using To_Do.Data;
using To_Do.DTO;
using To_Do.Entity;
using To_Do.Interfaces;

namespace To_Do.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(DataContext Context, ITokenService tokenService)
        {
            _context = Context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>>Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");
            var user = new AppUser
            {
                username=  registerDto.Username.ToLower(),
                password= registerDto.Password
                
                
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new UserDto
            {
                Username= user.username,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>>Login(LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.username == loginDto.username);
            if (user == null) return Unauthorized("Invalid Username");
            for(int i = 0; i < loginDto.password.Length;i++) 
            {
                if (loginDto.password[i] != user.password[i]) return Unauthorized("Invalid Password");
            }

            return new UserDto
            {
                Username = user.username,
                Token = _tokenService.CreateToken(user)
                
            };
            
        }
        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(X => X.username == username.ToLower());
        }
      
    }
}
