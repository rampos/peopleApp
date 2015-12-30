using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContactsClutter.Connectors
{
    public class MicrosoftConnector
    {
        public async Task<string> GetContactsAsync(string token)
        {
            Uri uri = new Uri("https://outlook.office.com/api/v2.0/me/contacts");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Add("X-AnchorMailbox", "ram_psg@hotmail.com");
            string response = await client.GetStringAsync(uri);

            var o = JObject.Parse(response);

            return response;
        }
    }
}
