using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddChallengeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChallengeId",
                table: "ToDos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_ChallengeId",
                table: "ToDos",
                column: "ChallengeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Challenges_ChallengeId",
                table: "ToDos",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Challenges_ChallengeId",
                table: "ToDos");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropIndex(
                name: "IX_ToDos_ChallengeId",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "ChallengeId",
                table: "ToDos");
        }
    }
}