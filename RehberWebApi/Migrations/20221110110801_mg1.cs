using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RehberWebApi.Migrations
{
    public partial class mg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rehbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firma = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rehbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IletisimBilgileris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelefoNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Konum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RehberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IletisimBilgileris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IletisimBilgileris_Rehbers_RehberId",
                        column: x => x.RehberId,
                        principalTable: "Rehbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IletisimBilgileris_RehberId",
                table: "IletisimBilgileris",
                column: "RehberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IletisimBilgileris");

            migrationBuilder.DropTable(
                name: "Rehbers");
        }
    }
}
