using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using Newtonsoft.Json;

namespace CryptoRack
{
    public partial class MainWindow : Window
    {
        private void TextBox_Clear(object sender, RoutedEventArgs e)
        {
            TextBox input = (TextBox)sender;
            input.Text = string.Empty;
            input.GotFocus -= TextBox_Clear;
        }

        public MainWindow()
        {
            InitializeComponent();
            BemenetLista = new List<double>();
            bemenet.ItemsSource = BemenetLista;
            KimenetLista = new List<double>();
            kimenet.ItemsSource = KimenetLista;
        }

        List<double> BemenetLista;
        List<double> KimenetLista;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BTCdata BTC = new BTCdata();
            ETHdata ETH = new ETHdata();
            string json;
            double percentileout = 0;
            double diffout = 0;
            using (var web = new System.Net.WebClient())
            {
                var url = @"https://min-api.cryptocompare.com/data/price?fsym=BTC&tsyms=USD&api_key=fe78af9dcc7d50bfca734160306572698d9a62690be9492c334f626ec4afdec0";
                json = web.DownloadString(url);
            }
            INPUTdata INBTC = JsonConvert.DeserializeObject<INPUTdata>(json);
            BTC.RoundUSD = (int)Math.Round(INBTC.USD);
            vm.BTCprice = BTC.RoundUSD;
            if (BTC.RoundUSD != BTC.PrevUSD)
            {
                BemenetLista.Add(BTC.RoundUSD);
                bemenet.Items.Refresh();
                if (BTC.PrevUSD != 0)
                {
                    diffout = BTC.RoundUSD - BTC.PrevUSD;
                    percentileout = Math.Round((BTC.RoundUSD / BTC.PrevUSD * 100 - 100), 3, MidpointRounding.AwayFromZero);
                }
                BTC.PrevUSD = BTC.RoundUSD;
            }

            using (var web = new System.Net.WebClient())
            {
                var url = @"https://min-api.cryptocompare.com/data/price?fsym=ETH&tsyms=USD&api_key=fe78af9dcc7d50bfca734160306572698d9a62690be9492c334f626ec4afdec0";
                json = web.DownloadString(url);
            }
            INPUTdata INETH = JsonConvert.DeserializeObject<INPUTdata>(json);
            ETH.RoundUSD = (int)Math.Round(INETH.USD);
            if (ETH.RoundUSD != ETH.PrevUSD)
            {
                KimenetLista.Add(ETH.RoundUSD);
                kimenet.Items.Refresh();
                if (ETH.PrevUSD != 0)
                {
                    diffout = ETH.RoundUSD - ETH.PrevUSD;
                    percentileout = Math.Round((ETH.RoundUSD / ETH.PrevUSD * 100 - 100), 3, MidpointRounding.AwayFromZero);
                }
                ETH.PrevUSD = ETH.RoundUSD;
            }
            
        }
        MainVM vm;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vm = (MainVM)(sender as Window).FindResource("VM");
        }
    }
}
