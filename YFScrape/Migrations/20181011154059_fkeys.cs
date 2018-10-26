using Microsoft.EntityFrameworkCore.Migrations;

namespace YFScrape.Migrations
{
    public partial class fkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stocks_PortfolioId",
                table: "Stocks",
                column: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Portfolios_PortfolioId",
                table: "Stocks",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Portfolios_PortfolioId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_PortfolioId",
                table: "Stocks");
        }
    }
}
