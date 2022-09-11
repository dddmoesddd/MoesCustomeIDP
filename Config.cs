// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.



using IdentityModel;
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
                            new IdentityResource("roles","Your Role",new List<string>(){"role"}),
                            new IdentityResource("countrypolicy","the country that you live in",new List<string>(){"country"}),
                            new IdentityResource("undersangtionpolicy","Is This Country Under International Sangtion? ",new List<string>(){"undersangtion"})
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {

            //new ApiResource(){Name="usertransactionapi",ApiSecrets={ new Secret("MyApiSecret".Sha256()) } },
        new ApiResource("usertransactionapi")
{
    UserClaims =
    {
        JwtClaimTypes.Audience,"role","country","undersangtion"
    },
    Scopes = new List<string>
    {
        "usertransactionapi",

    },
   ApiSecrets = { new Secret("apisecret".Sha256())}

},




    };
        public static IEnumerable<ApiScope> ApiScopes =>
    new ApiScope[]
    {
                new ApiScope(
                    "usertransactionapi",
                    "User Transaction Api")
    };
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
              new Client {
                   AccessTokenType = AccessTokenType.Reference,
                  AccessTokenLifetime=120,
                  AllowOfflineAccess=true,
                  UpdateAccessTokenClaimsOnRefresh=true,
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
                                     "usertransactionapi",
                                     "countrypolicy",
                                     "undersangtionpolicy"
                  },

                  ClientSecrets =
                  {
                      new Secret("secret".Sha256())

                  }
              }
            };
    }
}