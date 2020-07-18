using Microsoft.EntityFrameworkCore.Migrations;

namespace Starwars.Data.Migrations
{
    public partial class Addedtabletojoincharactersandepisodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_episodes_characters_CharacterModelId",
                table: "episodes");

            migrationBuilder.DropIndex(
                name: "IX_episodes_CharacterModelId",
                table: "episodes");

            migrationBuilder.DropColumn(
                name: "CharacterModelId",
                table: "episodes");

            migrationBuilder.CreateTable(
                name: "AssignedEpisodes",
                columns: table => new
                {
                    CharacterId = table.Column<long>(nullable: false),
                    EpisodeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedEpisodes", x => new { x.CharacterId, x.EpisodeId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedEpisodes");

            migrationBuilder.AddColumn<long>(
                name: "CharacterModelId",
                table: "episodes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_episodes_CharacterModelId",
                table: "episodes",
                column: "CharacterModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_episodes_characters_CharacterModelId",
                table: "episodes",
                column: "CharacterModelId",
                principalTable: "characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
