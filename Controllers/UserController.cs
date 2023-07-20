using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.IdentityModel.Tokens;
using nc2.Context;
using nc2.Models;
using nc2.Models.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace nc2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        NcDbContext _db;
        public UserController (NcDbContext db) { 
         _db= db;
        }


        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<User>> GetUsersList()
        {
            return (IEnumerable<User>)await _db.Users.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<User> GetUserById(int id)
        {
            return await _db.Users.FindAsync(id);
        }



        [HttpPost]

        public async Task<LoginUserDto> Post(User user)
        {
            LoginUserDto luo= new LoginUserDto();
            
            if(!_db.Users.Any(x=>x.uid== user.uid))
            {
                user.createdDate = DateTime.Now;
                user.modifiedDate = DateTime.Now;
                _db.Users.Add(user);
                Cloud newCloud = new Cloud()
                {
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    name = "New NoteCloud",
                    
                };
                _db.Clouds.Add(newCloud);
                await _db.SaveChangesAsync();
                 _db.UsersClouds.Add(new UserCloud() { userId = user.id, cloudId = newCloud.id });
                _db.Users.Update(user);
                await _db.SaveChangesAsync();
                luo.displayName = user.displayName;
                luo.cloudId= newCloud.id;
                luo.userId = user.id;
                luo.isNew = true;
                luo.token = CreateJWT(user);


            }

            else
            {
                var userId = _db.Users.FirstOrDefault(x => x.uid == user.uid).id;
                luo.userId= userId;
                luo.cloudId = _db.UsersClouds.FirstOrDefault(x => x.userId == userId).cloudId;
                luo.displayName = user.displayName;
                luo.isNew = false;
                luo.token = CreateJWT(user);
            }

            // return await _db.Users.Include("userClouds").ToListAsync();
            return luo;
        }



        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IEnumerable<User>> DeleteUser(int id)
        {
            _db.Users.Remove(_db.Users.Find(id));
            await _db.SaveChangesAsync();
            return _db.Users;

        }

        [HttpPut]
        [Authorize]
        public async Task<User> UpdateUser(User user)
        {
            user.modifiedDate = DateTime.Now;
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }

        private string CreateJWT(User user)
        {
            var secretKey = "gizli key cümlem bu";
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(secretKey));

            var claims = new Claim[] {
                new Claim(ClaimTypes.Name,user.displayName),
                new Claim(ClaimTypes.NameIdentifier,user.id.ToString()),
            //    new Claim ("role","user")
            };

            var signingCredentials = new SigningCredentials(
                    key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
         //   ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
         //   ClaimsPrincipal principal = new ClaimsPrincipal(identity);
         //   HttpContext.SignInAsync(principal);
            return tokenHandler.WriteToken(token);
        }

    }
}
