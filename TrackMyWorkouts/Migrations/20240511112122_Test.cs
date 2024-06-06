using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackMyWorkouts.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetLog_ExerciseCarriedOut_ExerciseCarriedOutId",
                table: "SetLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SetLog",
                table: "SetLog");

            migrationBuilder.RenameTable(
                name: "SetLog",
                newName: "SetLogs");

            migrationBuilder.RenameIndex(
                name: "IX_SetLog_ExerciseCarriedOutId",
                table: "SetLogs",
                newName: "IX_SetLogs_ExerciseCarriedOutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SetLogs",
                table: "SetLogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SetLogs_ExerciseCarriedOut_ExerciseCarriedOutId",
                table: "SetLogs",
                column: "ExerciseCarriedOutId",
                principalTable: "ExerciseCarriedOut",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetLogs_ExerciseCarriedOut_ExerciseCarriedOutId",
                table: "SetLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SetLogs",
                table: "SetLogs");

            migrationBuilder.RenameTable(
                name: "SetLogs",
                newName: "SetLog");

            migrationBuilder.RenameIndex(
                name: "IX_SetLogs_ExerciseCarriedOutId",
                table: "SetLog",
                newName: "IX_SetLog_ExerciseCarriedOutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SetLog",
                table: "SetLog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SetLog_ExerciseCarriedOut_ExerciseCarriedOutId",
                table: "SetLog",
                column: "ExerciseCarriedOutId",
                principalTable: "ExerciseCarriedOut",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
