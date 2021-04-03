using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TradingWebApplication.Models
{
    public class Portfolio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string Alpaca_Key { get; set; }
        public string Alpaca_Secret_Key { get; set; }
        public double Portfolio_Value { get; set; }
        public double Profit_Loss { get; set; }
        public int Trade_Type { get; set; }
        public Portfolio()
        {

        }
    }
}
