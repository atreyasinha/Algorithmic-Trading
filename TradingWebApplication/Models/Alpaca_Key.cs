using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TradingWebApplication.Models
{
    public class Alpaca_Key
    {
<<<<<<< HEAD
=======
        //Database ID
>>>>>>> e6b1a82 (Key is now primary Key for Alpaca_Keys - DB is seeded on creation with keys)
        //Alpaca Key
        [Key]
        public string Key { get; set; }

        //Alpaca Secret Key
        [Required]
        public string Secret_Key { get; set; }

        public Alpaca_Key()
        {
            this.Key = "";
            this.Secret_Key = "";
        }

        public Alpaca_Key(string C_key, string C_Secrety_Key)
        {
            this.Key = C_key;
            this.Secret_Key = C_Secrety_Key;
        }
    }
}
