using Microsoft.EntityFrameworkCore.Migrations;

namespace CbtApi.Infrastructure.Migrations
{
    public partial class DifficultyLevelSubjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_DifficultyLevel_DifficultyLevelId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subject_SubjectId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DifficultyLevel",
                table: "DifficultyLevel");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "Subjects");

            migrationBuilder.RenameTable(
                name: "DifficultyLevel",
                newName: "DifficultyLevels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DifficultyLevels",
                table: "DifficultyLevels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_DifficultyLevels_DifficultyLevelId",
                table: "Questions",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Subjects_SubjectId",
                table: "Questions",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_DifficultyLevels_DifficultyLevelId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subjects_SubjectId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DifficultyLevels",
                table: "DifficultyLevels");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Subject");

            migrationBuilder.RenameTable(
                name: "DifficultyLevels",
                newName: "DifficultyLevel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DifficultyLevel",
                table: "DifficultyLevel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_DifficultyLevel_DifficultyLevelId",
                table: "Questions",
                column: "DifficultyLevelId",
                principalTable: "DifficultyLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Subject_SubjectId",
                table: "Questions",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
