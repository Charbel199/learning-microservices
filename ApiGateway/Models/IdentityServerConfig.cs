using System.Collections.Generic;

namespace ApiGateway.Models
{
    public class IdentityServerConfig
    {
        public string IP { get; set; }
        public string Port { get; set; }
        public string IdentityScheme { get; set; }
        public List<APIResource> Resources { get; set; }
    }
}
