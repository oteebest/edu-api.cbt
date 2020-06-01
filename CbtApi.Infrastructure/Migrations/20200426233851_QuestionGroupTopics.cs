using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CbtApi.Infrastructure.Migrations
{
    public partial class QuestionGroupTopics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscriberId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SubscriberId",
                table: "Assessments");

            migrationBuilder.AddColumn<string>(
                name: "GroupId",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TopicId1",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Assessments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuestionGroups",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateOn = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionGroups_GroupId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Topics_TopicId1",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "QuestionGroups");

            migrationBuilder.DropTable(
                name: "Topics");

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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Assessments");

            migrationBuilder.AddColumn<string>(
                name: "SubscriberId",
                table: "Questions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubscriberId",
                table: "Assessments",
                type: "text",
                nullable: true);
        }
    }
}
