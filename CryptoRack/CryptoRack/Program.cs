using System;
using System.Threading;
using Newtonsoft.Json;

namespace CryptoRack
{
    class Program
    {
        static void Main(string[] args)
        {
            BTCdata BTC = new BTCdata();
            ETHdata ETH = new ETHdata();
            string json;
            double percentileout = 0;
            double diffout = 0;
            using (var web = new System.Net.WebClient())
            Console.WriteLine("\tCOIN\tPRICE\t[CHANGE]\t(CHANGE%)");
            for (; ;)
            {
                using (var web = new System.Net.WebClient())
                {
                    var url = @"https://min-api.cryptocompare.com/data/price?fsym=BTC&tsyms=USD&api_key=fe78af9dcc7d50bfca734160306572698d9a62690be9492c334f626ec4afdec0";
                    json = web.DownloadString(url);
                }
                INPUTdata INBTC = JsonConvert.DeserializeObject<INPUTdata>(json);
                BTC.RoundUSD = (int)Math.Round(INBTC.USD);

                if (BTC.RoundUSD != BTC.prevUSD)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("\tBTC:   ");
                    if (BTC.RoundUSD < BTC.prevUSD)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(BTC.RoundUSD + "$   ");
                    if (BTC.prevUSD != 0)
                    {
                        diffout = BTC.RoundUSD - BTC.prevUSD;
                        percentileout = Math.Round((BTC.RoundUSD / BTC.prevUSD * 100 - 100), 3, MidpointRounding.AwayFromZero);
                    }
                    Console.Write("[" + diffout + "$]          ");
                    Console.WriteLine("(" + percentileout + "%)   ");
                    BTC.prevUSD = BTC.RoundUSD;
                }
                Thread.Sleep(1000);
                
                using (var web = new System.Net.WebClient())
                {
                    var url = @"https://min-api.cryptocompare.com/data/price?fsym=ETH&tsyms=USD&api_key=fe78af9dcc7d50bfca734160306572698d9a62690be9492c334f626ec4afdec0";
                    json = web.DownloadString(url);
                }
                INPUTdata INETH = JsonConvert.DeserializeObject<INPUTdata>(json);
                ETH.RoundUSD = (int)Math.Round(INETH.USD);

                if (ETH.RoundUSD != ETH.prevUSD)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("\tETH:   ");
                    if (ETH.RoundUSD < ETH.prevUSD)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(ETH.RoundUSD + "$   ");
                    if (ETH.prevUSD != 0) 
                    {
                        diffout = ETH.RoundUSD - ETH.prevUSD;
                        percentileout = Math.Round((ETH.RoundUSD / ETH.prevUSD * 100 - 100), 3, MidpointRounding.AwayFromZero); 
                    }
                    Console.Write("[" + diffout + "$]          ");
                    Console.WriteLine("(" + percentileout + "%)   ");
                    ETH.prevUSD = ETH.RoundUSD;
                }
                Thread.Sleep(1000);
            }
        }
    }
}
