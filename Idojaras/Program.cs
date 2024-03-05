using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Idojaras;

namespace Idojaras
{
    internal class Program
    {
        static Weather ido = null;
        static async Task Main(string[] args)
        {
            Console.WriteLine("írd be a város nevét");
            string varos=Console.ReadLine();
            await helyek(varos);
            Console.WriteLine(ido);
            Console.ReadKey();
        }

        private static async Task helyek(string varos)
        {
            string url = $"https://api.api-ninjas.com/v1/weather?city={varos}";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Hiba a lekérdezés során");
            }
            string jsonString = await response.Content.ReadAsStringAsync();
            ido = Weather.FromJson(jsonString);
        }
    }
}
