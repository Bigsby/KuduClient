using KuduClient.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KuduClient
{
    public class KuduClient
    {
        private readonly string _username;
        private readonly string _password;

        public KuduClient(string baseUrl, string username, string password)
        {
            BaseUrl = baseUrl;
            _username = username;
            _password = password;
        }

        public string BaseUrl { get; private set; }

        public async Task<IEnumerable<Item>> GetItems(Item parent = null)
        {
            try
            {
                var url = null == parent ? BaseUrl : parent.Link;
                var uri = new Uri(url);
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", BuildAuthParameter());
                var response = await client.GetStringAsync(new Uri(url));
                return JsonConvert.DeserializeObject<IEnumerable<Item>>(response);
            }
            catch (Exception ex)
            {

                return new Item[0];
            }
        }

        private string BuildAuthParameter()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_username}:{_password}"));
        }
    }
}
