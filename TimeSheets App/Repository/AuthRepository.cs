using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TimeSheets_App.Data;
using TimeSheets_App.Model;

namespace TimeSheets_App.Repository
{
    public class AuthRepository:IAuthRepository
    {
        private TimesheetDbContext _dbContext;
        private IConfiguration _configuration;


        public AuthRepository(TimesheetDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;

        }

        public User AddUser(User user)
        {
            
            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();
            return user;
        }
        public string Login(LoginRequests loginRequests)
        {
            if (string.IsNullOrEmpty(loginRequests.UserName) || string.IsNullOrEmpty(loginRequests.Password))
            {
                throw new ArgumentException("Username and password must be provided.");
            }

            var user = _dbContext.Users.SingleOrDefault(s => s.UserName == loginRequests.UserName);

            if (user == null || !BCrypt.Net.BCrypt.EnhancedVerify(loginRequests.Password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            var claims = new List<Claim>
            {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim("Username", user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(10),
                signingCredentials: signIn
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
