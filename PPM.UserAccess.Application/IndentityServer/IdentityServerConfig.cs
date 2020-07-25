using IdentityServer4;
using IdentityServer4.Models;
using PPM.UserAccess.Application.Configuration;
using System.Collections.Generic;

namespace PPM.UserAccess.Application.IndentityServer
{
    public class IdentityServerConfig
    {
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("ppmAPI","Production Process Managment API")
            };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("ppmapi",new List<string> {"test"}),
                new IdentityResource(CustomClaimTypes.Permissions, new List<string>
                {
                    CustomClaimTypes.Permissions
                })
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ppm.WEB",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,


                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ppmapi"
                    }
                }
            };
        }
    }
}
