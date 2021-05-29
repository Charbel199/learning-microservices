using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityService.Configuration
{
    public class Config
    {
        public static List<Client> Clients = new List<Client>
        {
            //Adding initial Clients
            new Client
            {
                ClientId = "the-big-client",
                AllowedGrantTypes = new List<string> { GrantType.ClientCredentials },
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "my-api", "write", "read" },
                Claims = new List<ClientClaim>
                {
                    new ClientClaim("companyName", "John Doe LTD")
                    //more custom claims depending on the logic of the api
                },
                AccessTokenLifetime = 86400
            },
            new Client
            {
                ClientId = "charbel199",
                AllowedGrantTypes = new List<string> { GrantType.ClientCredentials },
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "my-api", "write", "read", "identitygithubservice" },
                AccessTokenLifetime = 86400
            }
        
        };

        public static List<ApiResource> ApiResources = new List<ApiResource>
        {
            //Adding initial API resource
            new ApiResource
            {
                Name = "my-api",
                DisplayName = "My Fancy Secured API",
                Scopes = new List<string>
                {
                    "write",
                    "read"
                }
            },
            new ApiResource
            {
                Name = "identitygithubservice",
                DisplayName = "identitygithubservice",
                Scopes = new List<string>
                {
                    "write",
                    "read"
                }
            }
        };

        public static IEnumerable<ApiScope> ApiScopes = new List<ApiScope>
        {
            //Adding initial API scopes
            new ApiScope("read"),
            new ApiScope("write")
        };
    }
}