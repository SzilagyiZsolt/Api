using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Konyvjelzo;

namespace Konyvjelzo
{
    internal class Program
    {
        static Konyv konyv = null;
        static async Task Main(string[] args)
        {
            Console.WriteLine("írd be a könyv ISBN számát!");
            int isbn=int.Parse(Console.ReadLine());
            await jelzo(isbn);
            Console.WriteLine($"Információ a könyvről {konyv.InfoUrl}");
            Console.WriteLine($"Borítója: {konyv.ThumbnailUrl}");
            Console.ReadKey();
        }

        private static async Task jelzo(int isbn)
        {
            string url = $"https://openlibrary.org/api/books?bibkeys=ISBN:{isbn},LCCN:93005405&format=json";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Hiba a lekérdezés során");
            }
            string jsonString = await response.Content.ReadAsStringAsync();
            konyv = Konyv.FromJson(jsonString);
        }
    }
}
