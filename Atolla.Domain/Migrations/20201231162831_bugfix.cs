using Microsoft.EntityFrameworkCore.Migrations;

namespace Atolla.Domain.Migrations
{
    public partial class bugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "STRING_KEY",
                table: "LOCALIZATION",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "STRING_KEY",
                table: "LOCALIZATION",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
