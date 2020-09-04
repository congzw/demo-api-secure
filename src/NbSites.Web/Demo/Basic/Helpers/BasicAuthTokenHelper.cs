using System;
using System.Text;

namespace NbSites.Web.Demo.Basic.Helpers
{
    public class BasicAuthTokenHelper
    {
        public string GenerateToken(string username, string password)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
        }
    }
}
