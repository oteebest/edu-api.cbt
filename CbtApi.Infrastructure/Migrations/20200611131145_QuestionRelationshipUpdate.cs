using Microsoft.EntityFrameworkCore.Migrations;

namespace CbtApi.Infrastructure.Migrations
{
    public partial class QuestionRelationshipUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_DifficultyLevel_DifficultyLevelId1",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subject_SubjectId1",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_DifficultyLevelId1",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SubjectId1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "DifficultyLevelId1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SubjectId1",
                table: "Questions");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "Questions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "DifficultyLevelId",
                table: "Questions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DifficultyLevelId",
                table: "Questions",
                column: "DifficultyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SubjectId",
                table: "Questions",
                column: "SubjectId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_DifficultyLevel_DifficultyLevelId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subject_SubjectId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_DifficultyLevelId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SubjectId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Questions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DifficultyLevelId",
                table: "Questions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DifficultyLevelId1",
                table: "Questions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubjectId1",
                table: "Questions",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DifficultyLevelId1",
                table: "Questions",
                column: "DifficultyLevelId1");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SubjectId1",
                table: "Questions",
                column: "SubjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_DifficultyLevel_DifficultyLevelId1",
                table: "Questions",
                column: "DifficultyLevelId1",
                principalTable: "DifficultyLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Subject_SubjectId1",
                table: "Questions",
                column: "SubjectId1",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
