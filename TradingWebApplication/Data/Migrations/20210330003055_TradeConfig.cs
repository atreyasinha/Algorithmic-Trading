using Microsoft.EntityFrameworkCore.Migrations;

namespace TradingWebApplication.Data.Migrations
{
    public partial class TradeConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "trade_type",
                table: "Portfolio",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "trade_type",
                table: "Portfolio");
        }
    }
}
