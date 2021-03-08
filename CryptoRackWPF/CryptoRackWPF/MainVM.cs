using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoRack
{
    class MainVM : ViewModelBase
    {
        private double btcamount;
        private double btcprice;
        private double result;
        public double BTCamount { get => btcamount; set => Set(ref btcamount, value); }
        public double BTCprice { get => btcprice; set => Set(ref btcprice, value); }
        public double Result { get => result; set => Set(ref result, value); }
        public MainVM()
        {
            this.PropertyChanged += MainVM_PropertyChanged;
        }

        private void MainVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "BTCamount":
                    Result = BTCamount * BTCprice;
                    break;
                default:
                    break;
            }
        }
    }
}
