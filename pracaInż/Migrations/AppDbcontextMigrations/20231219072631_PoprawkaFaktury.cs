using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInż.Migrations.AppDbcontextMigrations
{
    /// <inheritdoc />
    public partial class PoprawkaFaktury : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesItem_Documents_PurchaseOrderDocId",
                table: "InvoicesItem");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseOrderDocId",
                table: "InvoicesItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesItem_Documents_PurchaseOrderDocId",
                table: "InvoicesItem",
                column: "PurchaseOrderDocId",
                principalTable: "Documents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesItem_Documents_PurchaseOrderDocId",
                table: "InvoicesItem");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseOrderDocId",
                table: "InvoicesItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesItem_Documents_PurchaseOrderDocId",
                table: "InvoicesItem",
                column: "PurchaseOrderDocId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
