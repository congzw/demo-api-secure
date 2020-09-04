using System.Collections.Generic;
using System.Linq;

namespace NbSites.Web.Demo.Shared
{
    public interface IAuthService
    {
        bool Validate(string username, string password);
        Account GetAccount(string username);
    }

    public class AuthService : IAuthService
    {
        private readonly List<Account> _accounts = new List<Account>
        {
            new Account { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        };
        
        public bool Validate(string username, string password)
        {
            var user = _accounts.SingleOrDefault(x => x.Username == username && x.Password == password);
            return user != null;
        }

        public Account GetAccount(string username)
        {
            var user = _accounts.SingleOrDefault(x => x.Username == username);
            return user;
        }
    }

    public class Account
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
