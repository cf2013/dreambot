using Microsoft.EntityFrameworkCore.Migrations;

namespace dreambot.Migrations
{
    public partial class changenumbertostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "whatsapp",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "whatsapp",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
