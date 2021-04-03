using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradingWebApplication.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Portfolio",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Alpaca_Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alpaca_Secret_Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Portfolio_Value = table.Column<double>(type: "float", nullable: false),
                    Profit_Loss = table.Column<double>(type: "float", nullable: false),
                    Trade_Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
