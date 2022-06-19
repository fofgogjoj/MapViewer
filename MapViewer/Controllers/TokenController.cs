using MapViewer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MapViewer.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly MapViewerContext _context;

        public TokenController(IConfiguration config, MapViewerContext context)
        {
            _configuration = config;
            _context = context;
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="userData">Логин/пароль</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(User userData)
        {
            if (userData != null && userData.Login != null && userData.Password != null && userData.Login != "" && userData.Password != "")
            {
                var user = await GetUser(userData.Login, userData.Password);

                if (user != null)
                {

                    return Ok(new JwtSecurityTokenHandler().WriteToken(GetToken(user)));
                }
                else
                {
                    Person person = new Person
                    {
                        Login = userData.Login,
                        Password = Hash.StringToHash(userData.Password)
                    };
                    _context.Persons.Add(person);
                    _context.SaveChanges();

                    return Ok(new JwtSecurityTokenHandler().WriteToken(GetToken(person)));
                }
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Создание JWT токена
        /// </summary>
        /// <param name="user">пользователь, для которого нужно сгенерировать токен</param>
        /// <returns>JWT токен</returns>
        private JwtSecurityToken GetToken(Person user)
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Login", user.Login)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            return token;
        }

        /// <summary>
        /// Получение пользователя из БД
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Пользователь</returns>
        private async Task<Person> GetUser(string login, string password)
        {
            return await _context.Persons.FirstOrDefaultAsync(u => u.Login == login && u.Password == Hash.StringToHash(password));
        }
    }
}
public record class User(string Login, string Password);