using Microsoft.EntityFrameworkCore.Migrations;

namespace Starwars.Data.Migrations
{
    public partial class Changedassignedtablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignedEpisodes",
                table: "AssignedEpisodes");

            migrationBuilder.RenameTable(
                name: "AssignedEpisodes",
                newName: "assignedepisodes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_assignedepisodes",
                table: "assignedepisodes",
                columns: new[] { "CharacterId", "EpisodeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_assignedepisodes",
                table: "assignedepisodes");

            migrationBuilder.RenameTable(
                name: "assignedepisodes",
                newName: "AssignedEpisodes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignedEpisodes",
                table: "AssignedEpisodes",
                columns: new[] { "CharacterId", "EpisodeId" });
        }
    }
}
