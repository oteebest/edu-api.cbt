using Microsoft.EntityFrameworkCore.Migrations;

namespace CbtApi.Infrastructure.Migrations
{
    public partial class QuestionRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionGroups_GroupId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Topics_TopicId1",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_GroupId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TopicId1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "TopicId1",
                table: "Questions");

            migrationBuilder.AlterColumn<string>(
                name: "TopicId",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionGroupId",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionGroupId",
                table: "Questions",
                column: "QuestionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TopicId",
                table: "Questions",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionGroups_QuestionGroupId",
                table: "Questions",
                column: "QuestionGroupId",
                principalTable: "QuestionGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Topics_TopicId",
                table: "Questions",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionGroups_QuestionGroupId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Topics_TopicId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionGroupId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TopicId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "TopicId",
                table: "Questions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionGroupId",
                table: "Questions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "GroupId",
                table: "Questions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TopicId1",
                table: "Questions",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_GroupId",
                table: "Questions",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TopicId1",
                table: "Questions",
                column: "TopicId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionGroups_GroupId",
                table: "Questions",
                column: "GroupId",
                principalTable: "QuestionGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Topics_TopicId1",
                table: "Questions",
                column: "TopicId1",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
