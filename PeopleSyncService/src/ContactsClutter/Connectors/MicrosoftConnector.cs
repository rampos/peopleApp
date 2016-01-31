using ContactsClutter.Models;
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
        string nextLink = "https://outlook.office.com/api/v2.0/me/contacts/?%24skip=";
        string tok = @"EwB4Aul3BAAUo4xeBIbHjhBxWOFekj4Xy2fhaGQAAbDWzLvo8Kdb48MetWPHZJcSUsQT0GuAQUpKwzVNWeUk98hWW/ny790Hu/wJm1MHnQymIyqptFrG83eMyXXnXs6d/VculQgcobf1NZ7G2/vOT2BjhZF7r5geSMAK26E+5vc2Q4GoozGAOx9rIhyYkmZO/IEjU1MwB6KLXfUKT1m3Zww6mlK4h/HG661OUjWlDoEVIVFi/poiLRO19ZKk5wUIf98O1gd23L1IfMoaIzZmrq5vI8dMqSIRAV+xDmgg1vnnYmOdqEoL8PkRWSefi8d2Zo7RbuOovTHSzQNCw8dNL+ZV+MJM/suA7P6gugEVkneFM3okFfxWUuqGqKqAf2IDZgAACPaCw9jMo5OpSAEX5wocPcMiHqa5i3VXWayPpv2icOkmNHcpWJK4fX+zSY5FlMqar+adbYCekUOPMFKh1/L2zUv3vfpcI8BpDgzpftlbUzZ6rvaQbjdJUY0Vd1rkmb1TrUV5TazmBJVJ/f1jRQwJcP56w0VW9ziSjkM4XbDcSGQkMQZYCV8dU8bOupE0LXqTo3gjf/xjXHeyp+psCTWhnRnWdhbVToNiQhWksyMAq4n7XFD7DtuQJ9MWljBZdghlynHc3At+m6fXVr6bDE23s0JK05KljrEkCT/zjdDbNAtKbQOvkL7CAlwFYXIAiL4KNzBoJ4PaBZ8q2rBdCQAyIsRdfRg/qr2ibtNNQxDdZggubSrUwiwzgZaS+D1okRr6VXrGqIgv4GbyHo/wfOlyBBEKRAr/0F5EdUt9TzXthMcwj+F1ibb1u+DmFkNYocvv0ADWXAE=";
        public async Task<int> GetContactCount()
        {
            Uri uri = new Uri("https://outlook.office.com/api/v2.0/me/contacts/$count");
            HttpClient client = new HttpClient();            
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/*"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tok);
            client.DefaultRequestHeaders.Add("X-AnchorMailbox", "ram_psg@hotmail.com");
            string response = await client.GetStringAsync(uri);
            int contactCount = Convert.ToInt32(response);
            return contactCount;
        }

        private async Task<string> GetContactHelper(string uriToCall)
        {
            Uri uri = new Uri(uriToCall);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tok);
            client.DefaultRequestHeaders.Add("X-AnchorMailbox", "ram_psg@hotmail.com");
            string response = await client.GetStringAsync(uri);
            return response;
        }
        public async Task<List<Contact>> GetContactsAsync(string token)
        {
            //Uri uri = new Uri("https://outlook.office.com/api/v2.0/me/contacts");

            //HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tok);
            //client.DefaultRequestHeaders.Add("X-AnchorMailbox", "ram_psg@hotmail.com");
            //string response = await client.GetStringAsync(uri);

            int count = await GetContactCount();
            List<Contact> contacts = new List<Contact>();
            string response = await GetContactHelper("https://outlook.office.com/api/v2.0/me/contacts");
            JObject contactJObject = JObject.Parse(response);
            JArray array = (JArray)contactJObject["value"];
            int addSkipCount = 10;

            while (contacts.Count() < count)
            {
                foreach (JToken jToken in array)
                {
                    try
                    {
                        Contact contact = jToken.ToObject<Contact>();
                        contacts.Add(contact);
                    }
                    catch (Exception e)
                    {
                        Console.Write(e);
                    }
                }

                response = await GetContactHelper(nextLink + addSkipCount);
                contactJObject = JObject.Parse(response);
                array = (JArray)contactJObject["value"];                
                
                addSkipCount = addSkipCount + 10;
            }            

            return contacts;
        }
    }
}
