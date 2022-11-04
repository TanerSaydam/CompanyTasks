using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreateAQuizMVC.Migrations
{
    public partial class mg3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Question2",
                table: "Quizzes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question3",
                table: "Quizzes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question4",
                table: "Quizzes",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question2",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "Question3",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "Question4",
                table: "Quizzes");
        }
    }
}
