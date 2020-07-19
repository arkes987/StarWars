using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Starwars.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Planet = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    SaveDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "episodes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    SaveDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_episodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "assignedfriends",
                columns: table => new
                {
                    CharacterId = table.Column<long>(nullable: false),
                    FriendId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignedfriends", x => new { x.CharacterId, x.FriendId });
                    table.ForeignKey(
                        name: "FK_assignedfriends_characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_assignedfriends_characters_FriendId",
                        column: x => x.FriendId,
                        principalTable: "characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "assignedepisodes",
                columns: table => new
                {
                    CharacterId = table.Column<long>(nullable: false),
                    EpisodeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignedepisodes", x => new { x.CharacterId, x.EpisodeId });
                    table.ForeignKey(
                        name: "FK_assignedepisodes_characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assignedepisodes_episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assignedepisodes_EpisodeId",
                table: "assignedepisodes",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_assignedfriends_FriendId",
                table: "assignedfriends",
                column: "FriendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assignedepisodes");

            migrationBuilder.DropTable(
                name: "assignedfriends");

            migrationBuilder.DropTable(
                name: "episodes");

            migrationBuilder.DropTable(
                name: "characters");
        }
    }
}
