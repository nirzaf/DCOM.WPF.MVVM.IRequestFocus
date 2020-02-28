namespace DCOM.WPF.MVVM.IRequestFocus
{
    using System.Security.Authentication;

    public class LoginService : ILoginService
    {
        public void Login(string username, string password)
        {
            throw new AuthenticationException($"Login failed for {username}.");
        }
    }
}