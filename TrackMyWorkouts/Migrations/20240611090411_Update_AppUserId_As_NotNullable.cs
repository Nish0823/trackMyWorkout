using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackMyWorkouts.Migrations
{
    /// <inheritdoc />
    public partial class Update_AppUserId_As_NotNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseCarriedOut_AspNetUsers_ApplicationUserId",
                table: "ExerciseCarriedOut");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ExerciseCarriedOut",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseCarriedOut_AspNetUsers_ApplicationUserId",
                table: "ExerciseCarriedOut",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseCarriedOut_AspNetUsers_ApplicationUserId",
                table: "ExerciseCarriedOut");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ExerciseCarriedOut",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseCarriedOut_AspNetUsers_ApplicationUserId",
                table: "ExerciseCarriedOut",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
