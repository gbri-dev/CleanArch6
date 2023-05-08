using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infra.Data.Migrations
{
    public partial class mvpIncomeExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.CreateTable(
                name: "ProcessTypesValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessTypesValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncomesExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2(7)", precision: 2, scale: 7, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2(7)", precision: 2, scale: 7, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Money = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TypeValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomesExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomesExpenses_ProcessTypesValues_Id",
                        column: x => x.Id,
                        principalTable: "ProcessTypesValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProcessTypesValues",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Income" });

            migrationBuilder.InsertData(
                table: "ProcessTypesValues",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Expense" });

            migrationBuilder.InsertData(
                table: "ProcessTypesValues",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Outros" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomesExpenses");

            migrationBuilder.DropTable(
                name: "ProcessTypesValues");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);
        }
    }
}
