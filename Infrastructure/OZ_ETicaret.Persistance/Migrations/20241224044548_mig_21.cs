using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OZ_ETicaret.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CartItems",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CartItems");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Carts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
