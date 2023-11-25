using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInż.Migrations.AppDbcontextMigrations
{
    /// <inheritdoc />
    public partial class PoprawkiKomponentowKomputera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_GraphicsCardModels_GPUId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "ProcessorBasePower",
                table: "ProcessorModels");

            migrationBuilder.RenameColumn(
                name: "PowerConsumption",
                table: "GraphicsCardModels",
                newName: "Manufacturer");

            migrationBuilder.AddColumn<int>(
                name: "Manufacturer",
                table: "ProcessorModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "OperatingSystems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "GPUId",
                table: "Computers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Computers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_GraphicsCardModels_GPUId",
                table: "Computers",
                column: "GPUId",
                principalTable: "GraphicsCardModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_GraphicsCardModels_GPUId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "ProcessorModels");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OperatingSystems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Computers");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "GraphicsCardModels",
                newName: "PowerConsumption");

            migrationBuilder.AddColumn<string>(
                name: "ProcessorBasePower",
                table: "ProcessorModels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "GPUId",
                table: "Computers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_GraphicsCardModels_GPUId",
                table: "Computers",
                column: "GPUId",
                principalTable: "GraphicsCardModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
