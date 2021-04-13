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

        [ForeignKey("Alpaca_Key")]
        public string Alpaca_KeyId {get; set;}
        
        [Required]
        public virtual Alpaca_Key Alpaca_Key { get; set; }

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
