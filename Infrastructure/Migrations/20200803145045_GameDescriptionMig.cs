using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class GameDescriptionMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameDescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    GameTitle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameDescriptions_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Studios_Name",
                table: "Studios",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameDescriptions_GameId",
                table: "GameDescriptions",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameDescriptions_GameTitle_Description",
                table: "GameDescriptions",
                columns: new[] { "GameTitle", "Description" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Studios_Name",
                table: "Studios");
        }
    }
}
