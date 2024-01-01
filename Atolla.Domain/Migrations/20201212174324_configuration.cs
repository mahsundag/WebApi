using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace Atolla.Domain.Migrations
{
    public partial class configuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONFIGURATION",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    CREATE_DATE = table.Column<DateTime>(nullable: false),
                    CREATE_BY = table.Column<string>(maxLength: 256, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: false),
                    UPDATE_BY = table.Column<string>(maxLength: 256, nullable: true),
                    ROW_STATUS = table.Column<short>(nullable: false),
                    CONFIGURATION_KEY = table.Column<string>(maxLength: 100, nullable: true),
                    CONFIGURATION_VALUE = table.Column<string>(maxLength: 1000, nullable: true),
                    ENVIRONMENT = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONFIGURATION", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONFIGURATION");
        }
    }
}
