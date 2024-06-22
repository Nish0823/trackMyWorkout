using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackMyWorkouts.Migrations
{
    /// <inheritdoc />
    public partial class AddExTypeToExCarriedout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExerciseType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseTypeId",
                table: "ExerciseCarriedOut",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseCarriedOut_ExerciseTypeId",
                table: "ExerciseCarriedOut",
                column: "ExerciseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseCarriedOut_ExerciseType_ExerciseTypeId",
                table: "ExerciseCarriedOut",
                column: "ExerciseTypeId",
                principalTable: "ExerciseType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseCarriedOut_ExerciseType_ExerciseTypeId",
                table: "ExerciseCarriedOut");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseCarriedOut_ExerciseTypeId",
                table: "ExerciseCarriedOut");

            migrationBuilder.DropColumn(
                name: "ExerciseTypeId",
                table: "ExerciseCarriedOut");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExerciseType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
