using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class GameDescriptionMidTextNoIndxMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GameDescriptions_GameTitle_Description",
                table: "GameDescriptions");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "GameDescriptions",
                type: "MEDIUMTEXT",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_GameDescriptions_GameTitle",
                table: "GameDescriptions",
                column: "GameTitle",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GameDescriptions_GameTitle",
                table: "GameDescriptions");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "GameDescriptions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "MEDIUMTEXT");

            migrationBuilder.CreateIndex(
                name: "IX_GameDescriptions_GameTitle_Description",
                table: "GameDescriptions",
                columns: new[] { "GameTitle", "Description" },
                unique: true);
        }
    }
}
