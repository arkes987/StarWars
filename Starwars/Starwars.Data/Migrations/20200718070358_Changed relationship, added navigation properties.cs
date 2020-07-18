using Microsoft.EntityFrameworkCore.Migrations;

namespace Starwars.Data.Migrations
{
    public partial class Changedrelationshipaddednavigationproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_assignedepisodes_EpisodeId",
                table: "assignedepisodes",
                column: "EpisodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignedepisodes_characters_CharacterId",
                table: "assignedepisodes",
                column: "CharacterId",
                principalTable: "characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assignedepisodes_episodes_EpisodeId",
                table: "assignedepisodes",
                column: "EpisodeId",
                principalTable: "episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignedepisodes_characters_CharacterId",
                table: "assignedepisodes");

            migrationBuilder.DropForeignKey(
                name: "FK_assignedepisodes_episodes_EpisodeId",
                table: "assignedepisodes");

            migrationBuilder.DropIndex(
                name: "IX_assignedepisodes_EpisodeId",
                table: "assignedepisodes");
        }
    }
}
