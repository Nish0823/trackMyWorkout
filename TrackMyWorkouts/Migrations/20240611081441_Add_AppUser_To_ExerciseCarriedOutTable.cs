using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackMyWorkouts.Migrations
{
    /// <inheritdoc />
    public partial class Add_AppUser_To_ExerciseCarriedOutTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ExerciseCarriedOut",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseCarriedOut_ApplicationUserId",
                table: "ExerciseCarriedOut",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseCarriedOut_AspNetUsers_ApplicationUserId",
                table: "ExerciseCarriedOut",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseCarriedOut_AspNetUsers_ApplicationUserId",
                table: "ExerciseCarriedOut");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseCarriedOut_ApplicationUserId",
                table: "ExerciseCarriedOut");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ExerciseCarriedOut");
        }
    }
}
