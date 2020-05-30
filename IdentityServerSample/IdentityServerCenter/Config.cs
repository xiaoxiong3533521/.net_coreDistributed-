using System.Collections;
using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServerCenter{

    public class Config{
        public static IEnumerable<ApiResource> GetResource(){
            return new List<ApiResource>{
                new ApiResource("api","My Api")
            };
        }

        public static IEnumerable<Client> GetClients(){
            return new List<Client>{
                new Client(){
                    ClientId="client",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,  //Oauth的模式，4种模式
                    ClientSecrets={new Secret("secret".Sha256())},
                    AllowedScopes={"api"}
                }
            };
        }
    }
}