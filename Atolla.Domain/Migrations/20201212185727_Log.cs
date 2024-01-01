using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace Atolla.Domain.Migrations
{
    public partial class Log : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LOG",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    CREATE_DATE = table.Column<DateTime>(nullable: false),
                    CREATE_BY = table.Column<string>(maxLength: 256, nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(nullable: false),
                    UPDATE_BY = table.Column<string>(maxLength: 256, nullable: true),
                    ROW_STATUS = table.Column<short>(nullable: false),
                    SERVICE_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    METHOD_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    REQUEST_DATA = table.Column<string>(nullable: true),
                    RESPONSE_DATA = table.Column<string>(nullable: true),
                    REQUEST_DATE = table.Column<DateTime>(nullable: false),
                    RESPONSE_DATE = table.Column<DateTime>(nullable: false),
                    PROCESS_TIME = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOG", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOG");
        }
    }
}
