using Microsoft.EntityFrameworkCore.Migrations;

namespace CbtApi.Infrastructure.Migrations
{
    public partial class QuestionUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Questions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Questions");
        }
    }
}
