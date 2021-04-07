using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingWebApplication.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Alpaca_Key { get; set; }
        public string Alpaca_Secret_Key { get; set; }
        public double Portfolio_Value { get; set; }
        public double Profit_Loss { get; set; }

        public Portfolio()
        {

        }
    }
}
