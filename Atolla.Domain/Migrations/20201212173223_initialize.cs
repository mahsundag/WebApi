using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace Atolla.Domain.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GROUP",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    CREATE_DATE = table.Column<DateTime>(nullable: false),
                    CREATE_BY = table.Column<string>(maxLength: 256, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: false),
                    UPDATE_BY = table.Column<string>(maxLength: 256, nullable: true),
                    ROW_STATUS = table.Column<short>(nullable: false),
                    GROUP_CODE = table.Column<string>(nullable: true),
                    GROUP_NAME = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PARAMETER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    CREATE_DATE = table.Column<DateTime>(nullable: false),
                    CREATE_BY = table.Column<string>(maxLength: 256, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: false),
                    UPDATE_BY = table.Column<string>(maxLength: 256, nullable: true),
                    ROW_STATUS = table.Column<short>(nullable: false),
                    GROUP_ID = table.Column<int>(nullable: false),
                    GROUP_CODE = table.Column<string>(nullable: true),
                    PARAMETER_CODE = table.Column<string>(nullable: true),
                    PARAMETER_NAME = table.Column<string>(nullable: true),
                    PARAMETER_DESCRIPTION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARAMETER", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GROUP");

            migrationBuilder.DropTable(
                name: "PARAMETER");
        }
    }
}
