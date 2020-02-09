using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace RestSharpApp
{
    public class User
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}

namespace RestSharpApp
{
    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}

namespace RestSharpApp
{
    public class ApiCall
    {
        public async Task<IEnumerable<User>> ObterTodosUsuarios()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");

            var request = new RestRequest("todos", DataFormat.Json);

            var usuarios = await client.GetAsync<List<User>>(request);

            return usuarios;
        }

        public async Task<IRestResponse> InserirPost()
        {
            var post = new Post{ UserId =1, Title = "titulo", Body = "Corpo" };

            var client = new RestClient("https://jsonplaceholder.typicode.com");

            var request = new RestRequest("posts", DataFormat.Json);            

            //Adicionando Token na requisição
            request.AddHeader("Authorization", "Bearer " + "GET_JWT_TOKEN");
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(post);

            return await client.ExecuteAsync(request);            
        }
    }
}