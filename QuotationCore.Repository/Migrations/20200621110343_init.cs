using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuotationCore.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Detailing = table.Column<string>(nullable: true),
                    quantity = table.Column<decimal>(nullable: false),
                    UnitOfMeasure = table.Column<string>(nullable: true),
                    NCM = table.Column<int>(nullable: false),
                    PartNumber = table.Column<string>(nullable: true),
                    QuotationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Validations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResponseTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    QuotationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Validations_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_QuotationId",
                table: "Items",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Validations_QuotationId",
                table: "Validations",
                column: "QuotationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Validations");

            migrationBuilder.DropTable(
                name: "Quotations");
        }
    }
}
