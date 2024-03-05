using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ValutaValto;

namespace ValutaValto
{
    internal class Program
    {
        static valutavaltas valto = null;
        static async Task Main(string[] args)
        {
            Console.WriteLine("Mennyit szeretnél átváltani?");
            int forint=int.Parse(Console.ReadLine());
            await Valto();
            var euro = forint/valto.Rates["HUF"];
            var dollar = (forint/valto.Rates["HUF"])*valto.Rates["USD"];
            Console.WriteLine($"{forint}ft={euro}{valto.Base}");
            Console.WriteLine($"{forint}ft={dollar}USD");
            Console.ReadKey();
        }

        private static async Task Valto()
        {
            string url = $"https://infojegyzet.hu/webszerkesztes/php/valuta/api/v1/arfolyam/";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Hiba a lekérdezés során");
            }
            string jsonString = await response.Content.ReadAsStringAsync();
            valto = valutavaltas.FromJson(jsonString);
        }
    }
}
