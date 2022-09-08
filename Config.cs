// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.



using IdentityServer4.Models;
using System.Collections.Generic;

namespace MoesCustomIDP
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                 new IdentityResources.Profile(),
                            new IdentityResources.Address(),
                            new IdentityResource("roles","Your Role",new List<string>(){"role" })
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
            
            new ApiScope("usertransactionapi","User Transaction Api")
            };
        public  static void  getstring()
        {

        }
        public static IEnumerable<Client> Clients =>
            new Client[] 
            { 
              new Client {
                  ClientName="AccountTransactiom" ,
                  RequirePkce=true,
                  ClientId="accounttransactionclient",
                  AllowedGrantTypes=GrantTypes.Code,
                  RedirectUris =new List<string>{

                      "https://localhost:44372/signin-oidc"
                  },
                               PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:44372/signout-callback-oidc"
                    },
                  AllowedScopes =
                  {

                     IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                           IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
                            IdentityServer4.IdentityServerConstants.StandardScopes.Address,
                                     "roles",
                                     "usertransactionapi"
                  },

                  ClientSecrets =
                  {
                      new Secret("secret".Sha256())

                  }
              }
            };
    }
}