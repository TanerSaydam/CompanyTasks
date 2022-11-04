using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreateAQuizMVC.Migrations
{
    public partial class mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Question1 = table.Column<string>(type: "TEXT", nullable: true),
                    Answer1A = table.Column<string>(type: "TEXT", nullable: true),
                    Answer1B = table.Column<string>(type: "TEXT", nullable: true),
                    Answer1C = table.Column<string>(type: "TEXT", nullable: true),
                    Answer1D = table.Column<string>(type: "TEXT", nullable: true),
                    RightAnswer1 = table.Column<string>(type: "TEXT", nullable: true),
                    Answer2A = table.Column<string>(type: "TEXT", nullable: true),
                    Answer2B = table.Column<string>(type: "TEXT", nullable: true),
                    Answer2C = table.Column<string>(type: "TEXT", nullable: true),
                    Answer2D = table.Column<string>(type: "TEXT", nullable: true),
                    RightAnswer2 = table.Column<string>(type: "TEXT", nullable: true),
                    Answer3A = table.Column<string>(type: "TEXT", nullable: true),
                    Answer3B = table.Column<string>(type: "TEXT", nullable: true),
                    Answer3C = table.Column<string>(type: "TEXT", nullable: true),
                    Answer3D = table.Column<string>(type: "TEXT", nullable: true),
                    RightAnswer3 = table.Column<string>(type: "TEXT", nullable: true),
                    Answer4A = table.Column<string>(type: "TEXT", nullable: true),
                    Answer4B = table.Column<string>(type: "TEXT", nullable: true),
                    Answer4C = table.Column<string>(type: "TEXT", nullable: true),
                    Answer4D = table.Column<string>(type: "TEXT", nullable: true),
                    RightAnswer4 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quizzes");
        }
    }
}
