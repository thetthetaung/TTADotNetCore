using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TTADotNetCore.ConsoleApp3
{
    public class HttpClientExample
    {
        private readonly HttpClient _client;
        private readonly string _postEndpoint = "https://jsonplaceholder.typicode.com/postsz";

        public HttpClientExample()
        {
            _client = new HttpClient();
        }
        public async Task Read()
        {

            var response = await _client.GetAsync(_postEndpoint);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
            }
        }
        public async Task Edit(int id)
        {
            var response = await _client.GetAsync($"{_postEndpoint}/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("No data found");
                return;
            }

            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
            }

        }

        public async Task Create(string title, string body, int userId)
        {
            PostModel model = new PostModel()
            {
                body = body,
                title = title,
                userId = userId
            };// C# object/DotNet Object

            var jsonRequest = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonRequest, Encoding.UTF8, Application.Json);
            var response = await _client.PostAsync(_postEndpoint, content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
        public async Task Update(int id, string title, string body, int userId)
        {
            PostModel model = new PostModel()
            {
                id = id,
                body = body,
                title = title,
                userId = userId
            };// C# object/DotNet Object

            var jsonRequest = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonRequest, Encoding.UTF8, Application.Json);
            var response = await _client.PatchAsync($"{_postEndpoint}/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task Delete(int id)
        {
            var response = await _client.DeleteAsync($"{_postEndpoint}/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("No data found");
                return;
            }

            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
            }
        }

        public class PostModel
        {
            public int userId { get; set; }
            public int id { get; set; } //Auto-generate
            public string title { get; set; }
            public string body { get; set; }
        }
    }
}
