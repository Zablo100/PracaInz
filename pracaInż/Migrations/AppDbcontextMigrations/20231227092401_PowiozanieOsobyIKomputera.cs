using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInż.Migrations.AppDbcontextMigrations
{
    /// <inheritdoc />
    public partial class PowiozanieOsobyIKomputera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Computers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computers_EmployeeId",
                table: "Computers",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Employees_EmployeeId",
                table: "Computers",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Employees_EmployeeId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_EmployeeId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Computers");
        }
    }
}
