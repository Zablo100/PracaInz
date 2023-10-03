using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInż.Migrations.AppDbcontextMigrations
{
    /// <inheritdoc />
    public partial class DodanoCheckDrukarki : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MonthlyCheck",
                table: "Printers",
                type: "tinyint(1)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthlyCheck",
                table: "Printers");
        }
    }
}
