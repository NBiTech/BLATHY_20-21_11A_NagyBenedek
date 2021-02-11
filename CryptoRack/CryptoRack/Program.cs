using System;
using System.Threading;
using Newtonsoft.Json;

namespace CryptoRack
{
    class Program
    { 
        public class Prices
        {
            public double USD { get; set; }
        }

        static void Main(string[] args)
        {
            string json;
            double prevBTC = 0;

            for (; ;)
            {
                using (var web = new System.Net.WebClient())
                {
                    var url = @"https://min-api.cryptocompare.com/data/price?fsym=BTC&tsyms=USD&api_key=fe78af9dcc7d50bfca734160306572698d9a62690be9492c334f626ec4afdec0";
                    json = web.DownloadString(url);
                }
                Prices BTC = JsonConvert.DeserializeObject<Prices>(json);
                if (BTC.USD != prevBTC)
                {
                    Console.Write("Bitcoin price:asd ");
                    if (BTC.USD < prevBTC)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.Write(BTC.USD);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("$ asd");
                    prevBTC = BTC.USD;
                }
                Thread.Sleep(5000);
            }
        }
    }
}
