using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class AddActivityTypesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "ActivityTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ActivityTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutRecords_ActivityTypes_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "ActivityTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkoutRecords_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRecords_ActivityTypeId",
                table: "WorkoutRecords",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRecords_UserId",
                table: "WorkoutRecords",
                column: "UserId");
            string runningSql = "INSERT INTO [ActivityTypes] VALUES (NEWID(), 'Running', 0);";
            migrationBuilder.Sql(runningSql);
            string walkingSql = "INSERT INTO [ActivityTypes] VALUES (NEWID(), 'Walking', 1);";
            migrationBuilder.Sql(walkingSql);
            string swimmingSql = "INSERT INTO [ActivityTypes] VALUES (NEWID(), 'Swimmming', 2);";
            migrationBuilder.Sql(swimmingSql);
            string cyclingSql = "INSERT INTO [ActivityTypes] VALUES (NEWID(), 'Cycling', 3);";
            migrationBuilder.Sql(cyclingSql);
            string othersSql = "INSERT INTO [ActivityTypes] VALUES (NEWID(), 'Others', 4);";
            migrationBuilder.Sql(othersSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutRecords");

            migrationBuilder.DropTable(
                name: "ActivityTypes");
        }
    }
}
