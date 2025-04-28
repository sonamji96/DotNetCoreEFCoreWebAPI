using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFWEBAPI.Migrations
{
    /// <inheritdoc />
    public partial class t1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrencyTypeid",
                table: "BookPrice",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookPrice_CurrencyTypeid",
                table: "BookPrice",
                column: "CurrencyTypeid");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPrice_CurrencyTypes_CurrencyTypeid",
                table: "BookPrice",
                column: "CurrencyTypeid",
                principalTable: "CurrencyTypes",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPrice_CurrencyTypes_CurrencyTypeid",
                table: "BookPrice");

            migrationBuilder.DropIndex(
                name: "IX_BookPrice_CurrencyTypeid",
                table: "BookPrice");

            migrationBuilder.DropColumn(
                name: "CurrencyTypeid",
                table: "BookPrice");
        }
    }
}
