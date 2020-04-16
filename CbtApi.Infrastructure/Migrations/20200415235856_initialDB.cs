using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CbtApi.Infrastructure.Migrations
{
    public partial class initialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SubscriberId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(nullable: false),
                    QuestionType = table.Column<string>(maxLength: 50, nullable: false),
                    ShuffleOptions = table.Column<bool>(nullable: false),
                    OptionCount = table.Column<int>(nullable: false),
                    QuestionGroupId = table.Column<int>(nullable: false),
                    TopicId = table.Column<int>(nullable: false),
                    DifficultyLevelId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    ScoreValue = table.Column<int>(nullable: false),
                    SubscriberId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(nullable: false),
                    AssessmentId = table.Column<string>(nullable: true),
                    QuestionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentQuestions_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(nullable: false),
                    IsAnswer = table.Column<bool>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    QuestionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentQuestions_QuestionId",
                table: "AssessmentQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentQuestions_AssessmentId_QuestionId",
                table: "AssessmentQuestions",
                columns: new[] { "AssessmentId", "QuestionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessmentQuestions");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
