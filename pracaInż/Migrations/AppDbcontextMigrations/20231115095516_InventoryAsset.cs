using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInż.Migrations.AppDbcontextMigrations
{
    /// <inheritdoc />
    public partial class InventoryAsset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IPAddress",
                table: "Devices",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<short>(
                name: "Amount",
                table: "Devices",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Devices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Devices",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FixedAssetClassification",
                table: "Devices",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<byte>(
                name: "InventoryBookNumber",
                table: "Devices",
                type: "tinyint unsigned",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InventoryNumber",
                table: "Devices",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "OrginalPrice",
                table: "Devices",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "YearOfPurches",
                table: "Devices",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DepartmentId",
                table: "Devices",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Departments_DepartmentId",
                table: "Devices",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Departments_DepartmentId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_DepartmentId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "FixedAssetClassification",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "InventoryBookNumber",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "InventoryNumber",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "OrginalPrice",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "YearOfPurches",
                table: "Devices");

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "IPAddress",
                keyValue: null,
                column: "IPAddress",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "IPAddress",
                table: "Devices",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
