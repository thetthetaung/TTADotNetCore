using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static TTADotNetCore.ConsoleApp3.HttpClientExample;

namespace TTADotNetCore.ConsoleApp3
{
    public class RestClientExample
    {
        private readonly RestClient _client;
        private readonly string _postEndpoint = "https://jsonplaceholder.typicode.com/posts";

        public RestClientExample()
        {
            _client = new RestClient();
        }
        public async Task Read()
        {
            RestRequest request = new RestRequest(_postEndpoint,Method.Get);
            var response = await _client.GetAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr =  response.Content!;
                Console.WriteLine(jsonStr);
            }
        }
        public async Task Edit(int id)
        {
            RestRequest request=new RestRequest($"{_postEndpoint}/{id}", Method.Get);
            var response = await _client.GetAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("No data found");
                return;
            }

            if (response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content!;
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

            RestRequest request=new RestRequest(_postEndpoint,Method.Post);
            request.AddJsonBody(model);

            var response = await _client.ExecuteAsync(request);//PostAsync
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content!);
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

            RestRequest request=new RestRequest(_postEndpoint, Method.Patch);
            var response = await _client.ExecuteAsync(request); //PatchAsync
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content!);
            }
        }

        public async Task Delete(int id)
        {
            RestRequest request = new RestRequest($"{_postEndpoint}/{id}", Method.Delete);

            var response = await _client.ExecuteAsync(request); //good point to use executeAsync.According to method of delete

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("No data found");
                return;
            }

            if (response.IsSuccessStatusCode)
            {
                var jsonStr =  response.Content!;
                Console.WriteLine(jsonStr);
            }
        }
    }
}
