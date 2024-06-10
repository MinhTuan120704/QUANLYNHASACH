using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTable_Employee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Receipt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_EmployeeID",
                table: "Receipt",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeID",
                table: "Order",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Account_EmployeeID",
                table: "Account",
                column: "EmployeeID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Employee_EmployeeID",
                table: "Account",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employee_EmployeeID",
                table: "Order",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Employee_EmployeeID",
                table: "Receipt",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Employee_EmployeeID",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employee_EmployeeID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Employee_EmployeeID",
                table: "Receipt");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Receipt_EmployeeID",
                table: "Receipt");

            migrationBuilder.DropIndex(
                name: "IX_Order_EmployeeID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Account_EmployeeID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Account");
        }
    }
}
