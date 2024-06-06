using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackMyWorkouts.Migrations
{
    /// <inheritdoc />
    public partial class added_exerciseTypeCarriedOutTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseTypeCarriedOut",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseCarriedOutId = table.Column<int>(type: "int", nullable: false),
                    ExerciseTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypeCarriedOut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseTypeCarriedOut_ExerciseCarriedOut_ExerciseCarriedOutId",
                        column: x => x.ExerciseCarriedOutId,
                        principalTable: "ExerciseCarriedOut",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTypeCarriedOut_ExerciseType_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypeCarriedOut_ExerciseCarriedOutId",
                table: "ExerciseTypeCarriedOut",
                column: "ExerciseCarriedOutId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTypeCarriedOut_ExerciseTypeId",
                table: "ExerciseTypeCarriedOut",
                column: "ExerciseTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseTypeCarriedOut");
        }
    }
}
