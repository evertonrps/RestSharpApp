using System;
using System.Threading.Tasks;
using RestSharp;

namespace RestSharpApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Run().Wait();
        }

         static async Task Run()
         {
            Console.WriteLine("Hello World!");

            var api = new ApiCall();

            var ret = await api.ObterTodosUsuarios();

            var response = await api.InserirPost();

            Console.ReadLine();
         }
    }
}
