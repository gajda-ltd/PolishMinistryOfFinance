using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PolishMinistryOfFinance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxIdentificationNumbers",
                columns: table => new
                {
                    Number = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxIdentificationNumbers", x => x.Number);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxIdentificationNumbers");
        }
    }
}
