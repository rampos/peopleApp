using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PeopleFixWebApp.Connectors
{
    public class MicrosoftConnector
    {
        public async Task<string> GetContactsAsync()
        {
            Uri uri = new Uri("https://outlook.office.com/api/v2.0/me/contacts");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "EwB4Aul3BAAUo4xeBIbHjhBxWOFekj4Xy2fhaGQAAasf8ju+eHom5g0MquNWBF09y6avqKXY1k8fHICyD+9KK50CKTVu8GPcUp4sAyzKHZ7Ypj9QVWQW8ofkrdgmBqz/oWBZjcG9DvENQEfq7+ZuKgvIHJy+JQcYKxtHmRiLGngqzeqmERHE917TwDKFuUXNBN4WQyAARhNUBgHKEZ8VcGeNLGayALecElrzzF1pLet8nOzfhM9KZivD9+UnYei4N8EXVZc4UXaXkk3jjvfhbOW/TdPgLGw1WFKWrkFRWXHGL07ZkuO3rmaW6e7Sv/tX5BPJlePwR+9hVKdq6KIAP2Tpjkod8oQD+lobza3hKCsEAoTho+O+9j7lHc7ibYEDZgAACH5ZF2QQwUgZSAFrVeA732LxysyjWkVugc6xK6cl1rJQQmP3k/vfabvXu1i2qG1GRVM5c11OOd7wNR11plP/2X7DgVjlUIdHHmZyMJEUJObkonLCNhqgVmAf/4z20JQ/v6t50fsSYYymCqLnaqtJLDMuvK9GLBbGmBg1NGNiLrPX3GLQ34wgc4NU8DSpSngHhApggoaRO2ZQxvZYUqUHD3ekakvBxfc710SwNj5tffH9zeE2AhyvORiwIDggIJsu+VzGtJCTKguzVnHzasWFhIFhOZll8D0knfK+1XSv3x53Y5x3KsDmwII7tkO7Hd3xhgtXjGTnlKo3UH5PJBQZ3JOHVzxSxtvyp2/MjkXLzW2SCCe4bhm6xxvP+Hbad11yoEMsyZV48zrWXdnTNqmscysOvjkjf47TvaGM+iS1IwggZ7inll2vggVFyD5N0jOtmuhpXAE=");
            client.DefaultRequestHeaders.Add("X-AnchorMailbox", "ram_psg@hotmail.com");
            string response = await client.GetStringAsync(uri);

            var o = JObject.Parse(response);

            return response;
        }
    }
}