using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TimeSheets_App.Data;
using TimeSheets_App.Model;
using TimeSheets_App.Repository;

namespace TimeSheets_App.Service
{
    public class AuthService : IAuthService
    {
        private IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
           _authRepository = authRepository;
        }

        public User AddUser(User user)
        {
            user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password);
            _authRepository.AddUser(user);
            return user;
        }
        public string Login(LoginRequests loginRequests)
        {
           return _authRepository.Login(loginRequests);
            
        }

    }
}
