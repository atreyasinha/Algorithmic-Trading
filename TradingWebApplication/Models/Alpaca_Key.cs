using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TradingWebApplication.Models
{
    public class Alpaca_Key
    {
        //Alpaca Key
        [Key]
        public string Key { get; set; }

        //Alpaca Secret Key
        [Required]
        public string Secret_Key { get; set; }

        public virtual Portfolio Portfolio { get; set; }

        public Alpaca_Key()
        {
            this.Key = "";
            this.Secret_Key = "";
        }

        public Alpaca_Key(string C_key, string C_Secret_Key)
        {
            this.Key = C_key;
            this.Secret_Key = C_Secret_Key;
        }
    }
}
