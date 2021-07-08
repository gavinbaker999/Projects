using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WebAPIQuickStart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set these values:
            // e.g. https://yourorg.crm.dynamics.com
            string url = "https://orgdcfcc54b.crm11.dynamics.com";
            // e.g. you@yourorg.onmicrosoft.com
            string userName = "gavinbaker@endhousesoftware999.onmicrosoft.com";
            // e.g. y0urp455w0rd
            string password = "Joide333%";

            // Azure Active Directory registered app clientid for Microsoft samples
            string clientId = "51f81489-12ee-4a9e-aaae-a2591f45987d";

            var userCredential = new UserCredential(userName, password);
            string apiVersion = "9.0";
            string webApiUrl = $"{url}/api/data/v{apiVersion}/";

            //Authenticate using IdentityModel.Clients.ActiveDirectory
            var authParameters = AuthenticationParameters.CreateFromResourceUrlAsync(new Uri(webApiUrl)).Result;
            var authContext = new AuthenticationContext(authParameters.Authority, false);
            var authResult = authContext.AcquireToken(url, clientId, userCredential);
            var authHeader = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webApiUrl);
                client.DefaultRequestHeaders.Authorization = authHeader;

                // Use the WhoAmI function
                var response = client.GetAsync("WhoAmI").Result;

                if (response.IsSuccessStatusCode)
                {
                    //Get the response content and parse it.  
                    JObject body = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                    Guid userId = (Guid)body["UserId"];
                    Console.WriteLine("Your UserId is {0}", userId);
                }
                else
                {
                    Console.WriteLine("The request failed with a status of '{0}'",
                                response.ReasonPhrase);
                }

                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();
            }
        }
    }
}
