using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TradingWebApplication.Models;

namespace TradingWebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TradingWebApplication.Models.Portfolio> Portfolio { get; set; }
        public DbSet<TradingWebApplication.Models.Alpaca_Key> Alpaca_Keys { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Alpaca_Key>().HasData(new Alpaca_Key { Key = "PKA6END5AE2FCFY4BJ8S", Secret_Key = "Q9rNaxmOTMTgVIVyEHnnGO9jEvqP17cgaC2MOvyo" });
            builder.Entity<Alpaca_Key>().HasData(new Alpaca_Key { Key = "PKO3D0U580U6LZ1BY4BJ", Secret_Key = "q2ilG2CgqewreQ9a9vicwn80GPZN1pATbLv4LkvF" });
            builder.Entity<Alpaca_Key>().HasData(new Alpaca_Key { Key = "PKY4HXGTXXR9I7EYH7S2", Secret_Key = "w2R0XaDIodMaPgSaMUSJOvzIrkkE63bjKzoFdWNV" });
            builder.Entity<Alpaca_Key>().HasData(new Alpaca_Key { Key = "PKSG8HUEQDFECZBI8PZ9", Secret_Key = "OGmuwdATW3d4Sr8AlYhwi5NF0jAlE06VkQJoSJsK" });
            builder.Entity<Alpaca_Key>().HasData(new Alpaca_Key { Key = "PK2AZPW94C9WIILX53Y1", Secret_Key = "wAYYgsxlOQKt0rlX0zAdeGrK67eqRzpldKkIgdJP" });
        }
    }
}
