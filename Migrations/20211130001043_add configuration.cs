using Microsoft.EntityFrameworkCore.Migrations;

namespace dreambot.Migrations
{
    public partial class addconfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Teacher = table.Column<string>(nullable: true),
                    currentModule = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
