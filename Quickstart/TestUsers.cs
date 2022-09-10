// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using IdentityServer4;

namespace IdentityServerHost.Quickstart.UI
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "One Hacker Way",
                    locality = "Heidelberg",
                    postal_code = 69118,
                    country = "Germany"
                };

                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "818727",
                        Username = "alice",
                        Password = "alice",
                        Claims =
                        {
                           // new Claim(JwtClaimTypes.Name, "Alice Smith"),
                           //new Claim(JwtClaimTypes.Role, "freeuser"),
                           // new Claim(JwtClaimTypes.Address, "javadieh"),
                           // new Claim(JwtClaimTypes.GivenName, "Alice"),
                           // new Claim(JwtClaimTypes.FamilyName, "Smith")
                                            new Claim("given_name", "Frank"),
                     new Claim("family_name", "Underwood"),
                     new Claim("address", "Main Road 1"),
                     new Claim("role", "FreeUser"),
                     new Claim("country", "iran"),
                      new Claim("undersangtion", "y"),


                        }
                    },
                    new TestUser
                    {
                        SubjectId = "88421113",
                        Username = "bob",
                        Password = "bob",
                        Claims =
                        {
                           new Claim("country", "sapin"),
                           new Claim("undersangtion", "n"),
                           new Claim(JwtClaimTypes.Role, "VIPUser"),
                           new Claim(JwtClaimTypes.Name, "Bob Smith"),
                           new Claim(JwtClaimTypes.GivenName, "Bob"),
                           new Claim(JwtClaimTypes.FamilyName, "Smith"),
                           new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                           new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                           new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                           new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    }
                };
            }
        }
    }
}