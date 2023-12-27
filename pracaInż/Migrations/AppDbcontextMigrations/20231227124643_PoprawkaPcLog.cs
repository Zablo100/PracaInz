using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInż.Migrations.AppDbcontextMigrations
{
    /// <inheritdoc />
    public partial class PoprawkaPcLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PcLogs_Computers_ComputerId",
                table: "PcLogs");

            migrationBuilder.AlterColumn<int>(
                name: "ComputerId",
                table: "PcLogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PcLogs_Computers_ComputerId",
                table: "PcLogs",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PcLogs_Computers_ComputerId",
                table: "PcLogs");

            migrationBuilder.AlterColumn<int>(
                name: "ComputerId",
                table: "PcLogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PcLogs_Computers_ComputerId",
                table: "PcLogs",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
