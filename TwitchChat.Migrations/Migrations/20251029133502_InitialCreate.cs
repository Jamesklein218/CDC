using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitchChat.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MessageType = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwitchUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwitchLivestreamId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatUsers",
                columns: table => new
                {
                    TwitchUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscribeCount = table.Column<int>(type: "int", nullable: false),
                    TotalSubscribeMoney = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUsers", x => x.TwitchUserId);
                });

            migrationBuilder.CreateTable(
                name: "LeaderboardSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LivestreamId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentToSpam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderboardSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiveStreamSessions",
                columns: table => new
                {
                    TwitchLivestreamId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveStreamSessions", x => x.TwitchLivestreamId);
                });

            migrationBuilder.CreateTable(
                name: "ChatUserSessionScores",
                columns: table => new
                {
                    LeaderboardSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUserSessionScores", x => new { x.UserId, x.LeaderboardSessionId });
                    table.ForeignKey(
                        name: "FK_ChatUserSessionScores_ChatUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ChatUsers",
                        principalColumn: "TwitchUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatUserSessionScores_LeaderboardSessions_LeaderboardSessionId",
                        column: x => x.LeaderboardSessionId,
                        principalTable: "LeaderboardSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatUserSessionScores_LeaderboardSessionId",
                table: "ChatUserSessionScores",
                column: "LeaderboardSessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "ChatUserSessionScores");

            migrationBuilder.DropTable(
                name: "LiveStreamSessions");

            migrationBuilder.DropTable(
                name: "ChatUsers");

            migrationBuilder.DropTable(
                name: "LeaderboardSessions");
        }
    }
}
