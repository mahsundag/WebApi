using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace Atolla.Domain.Migrations
{
    public partial class Localization_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LOCALIZATION",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    CREATE_DATE = table.Column<DateTime>(nullable: false),
                    CREATE_BY = table.Column<string>(maxLength: 256, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: false),
                    UPDATE_BY = table.Column<string>(maxLength: 256, nullable: true),
                    ROW_STATUS = table.Column<short>(nullable: false),
                    STRING_KEY = table.Column<int>(nullable: false),
                    LANGUAGE_CODE = table.Column<string>(nullable: false),
                    STRING_VALUE = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCALIZATION", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOCALIZATION");
        }
    }
}
