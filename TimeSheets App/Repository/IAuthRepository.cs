using TimeSheets_App.Model;

namespace TimeSheets_App.Repository
{
    public interface IAuthRepository
    {
        public User AddUser(User user);

        public string Login(LoginRequests loginRequests);
    }
}
