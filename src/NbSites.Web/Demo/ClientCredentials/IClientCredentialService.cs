using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbSites.Web.Demo.ClientCredentials
{
    public interface IClientCredentialService
    {
        Task<ClientCredential> Authenticate(string clientId, string clientSecret);
    }

    public class ClientCredentialService : IClientCredentialService
    {
        public async Task<ClientCredential> Authenticate(string clientId, string clientSecret)
        {
            var client = await Task.Run(() => _clients.SingleOrDefault(x => x.ClientId == clientId && x.ClientSecret == clientSecret));
            return client;
        }

        //mock data
        //Client Id: test
        //Client Password: test
        //Client Name: NbSiteClient
        //Client Secret: f9bc40
        private readonly List<ClientCredential> _clients = new List<ClientCredential>
        {
            new ClientCredential { ClientId = "test", ClientSecret = "test", ClientName = "NbSiteClient"}
        };
    }
}