using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class RemovedActivityTypeIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutRecords_ActivityTypes_ActivityTypeId",
                table: "WorkoutRecords");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutRecords_ActivityTypeId",
                table: "WorkoutRecords");

            migrationBuilder.DropColumn(
                name: "ActivityTypeId",
                table: "WorkoutRecords");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRecords_ActivityId",
                table: "WorkoutRecords",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutRecords_ActivityTypes_ActivityId",
                table: "WorkoutRecords",
                column: "ActivityId",
                principalTable: "ActivityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutRecords_ActivityTypes_ActivityId",
                table: "WorkoutRecords");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutRecords_ActivityId",
                table: "WorkoutRecords");

            migrationBuilder.AddColumn<Guid>(
                name: "ActivityTypeId",
                table: "WorkoutRecords",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRecords_ActivityTypeId",
                table: "WorkoutRecords",
                column: "ActivityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutRecords_ActivityTypes_ActivityTypeId",
                table: "WorkoutRecords",
                column: "ActivityTypeId",
                principalTable: "ActivityTypes",
                principalColumn: "Id");
        }
    }
}
