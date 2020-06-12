using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CbtApi.Infrastructure.Migrations
{
    public partial class AssessmentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionGroups_QuestionGroupId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Topics_TopicId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "QuestionGroups");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionGroupId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TopicId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionGroupId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "DifficultyLevelId1",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubjectId1",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Assessments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "Assessments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DifficultyLevel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_DifficultyLevel_DifficultyLevelId1",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subject_SubjectId1",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "DifficultyLevel");

            migrationBuilder.DropTable(
                name: "Subject");

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

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "Assessments");

            migrationBuilder.AddColumn<string>(
                name: "QuestionGroupId",
                table: "Questions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TopicId",
                table: "Questions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "QuestionGroups",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

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
    }
}
