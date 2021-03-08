using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoRack
{
    public class BTCdata : ObservableObject
    {
        private double roundUSD;
        private double prevUSD;

        public double RoundUSD { get => roundUSD; set => Set(ref roundUSD, value); }
        public double PrevUSD { get => prevUSD; set => Set(ref prevUSD, value); }
    }
}
