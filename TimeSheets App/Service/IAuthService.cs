using TimeSheets_App.Model;

namespace TimeSheets_App.Service
{
    public interface IAuthService
    {
        public User AddUser(User user);

        public string Login(LoginRequests loginRequests);
    }
}
