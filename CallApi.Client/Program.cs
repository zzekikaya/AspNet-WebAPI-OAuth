using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace CallApi.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Dictionary<string, string> tokenDetails = null;
                //var messageDetails = new Message { Id = 4, Message1 = des };
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:55992/");
                var login = new Dictionary<string, string>
                {
                    {"grant_type", "password"},
                    {"username", "Zeki"},
                    {"password", "123456"},
                };
                var response = client.PostAsync("Token", new FormUrlEncodedContent(login)).Result;
                if (response.IsSuccessStatusCode)
                {
                    tokenDetails = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content.ReadAsStringAsync().Result);
                    if (tokenDetails != null && tokenDetails.Any())
                    {
                        var tokenNo = tokenDetails.FirstOrDefault().Value;
                        client.DefaultRequestHeaders.Clear();
                        //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenNo);

                        var responseGet = client.GetAsync("http://localhost:55992/api/Orders/List").Result;

                        var jsonString2 = responseGet.Content.ReadAsStringAsync();
                        var finalyResult = JsonConvert.DeserializeObject<object>(jsonString2.Result);

                    }
                }
            }

        }
    }
}
