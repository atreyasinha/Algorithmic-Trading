using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TradingWebApplication.Models
{
    public class Portfolio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        //The ID (in the Database) Referencing the Alpaca_Key object
        [Required]
        public int Alpaca_KeyId { get; set; }
        //The Alaca_Key Object
        public Alpaca_Key Alpaca_Key { get; set; }
        [Required]
        public double Portfolio_Value { get; set; }
        [Required]
        public double Profit_Loss { get; set; }
        public int Trade_Type { get; set; }
        public Portfolio()
        {
            Alpaca_Key = new Alpaca_Key();
        }
    }
}
