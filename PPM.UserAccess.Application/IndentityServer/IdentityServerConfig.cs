using IdentityServer4;
using IdentityServer4.Models;
using PPM.UserAccess.Application.Configuration;
using PPM.UserAccess.Domain.Users;
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
                new IdentityResource("ppmWEB",new List<string>
                {
                    UserPermission.View.Permission,
                    UserPermission.CanEditLocation.Permission,
                    UserPermission.ManageUsers.Permission,
                    UserPermission.EditFlow.Permission,
                    UserPermission.EmployeeAcess.Permission
                }),
                new IdentityResource(CustomClaimTypes.Permissions, new List<string>
                {
                    CustomClaimTypes.Permissions
                }),
                new IdentityResource("ppmMobile", new List<string>
                {
                    UserPermission.View.Permission,
                    UserPermission.CanExecuteFlow.Permission
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
                    AllowOfflineAccess = true,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    RefreshTokenUsage = TokenUsage.ReUse,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {
                        "ppmAPI",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                    }
                },
                new Client
                {
                    ClientId = "ppm.Mobile",
                    RefreshTokenUsage = TokenUsage.ReUse,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("mobile".Sha256())
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "ppmAPI"
                    }

                }
            };
        }
    }
}
