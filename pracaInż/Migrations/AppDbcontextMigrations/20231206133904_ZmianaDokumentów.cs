using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pracaInż.Migrations.AppDbcontextMigrations
{
    /// <inheritdoc />
    public partial class ZmianaDokumentów : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesItem_PurchaseOrderDocuments_PurchaseOrderDocId",
                table: "InvoicesItem");

            migrationBuilder.DropTable(
                name: "ManualDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseOrderDocuments",
                table: "PurchaseOrderDocuments");

            migrationBuilder.RenameTable(
                name: "PurchaseOrderDocuments",
                newName: "Documents");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreateAt",
                table: "Documents",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Documents",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateOnly>(
                name: "LastUpdate",
                table: "Documents",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesItem_Documents_PurchaseOrderDocId",
                table: "InvoicesItem",
                column: "PurchaseOrderDocId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesItem_Documents_PurchaseOrderDocId",
                table: "InvoicesItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Documents");

            migrationBuilder.RenameTable(
                name: "Documents",
                newName: "PurchaseOrderDocuments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseOrderDocuments",
                table: "PurchaseOrderDocuments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ManualDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SoftwareId = table.Column<int>(type: "int", nullable: true),
                    CreateAt = table.Column<DateOnly>(type: "date", nullable: false),
                    Extension = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastUpdate = table.Column<DateOnly>(type: "date", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PathToFile = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManualDocuments_Software_SoftwareId",
                        column: x => x.SoftwareId,
                        principalTable: "Software",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ManualDocuments_SoftwareId",
                table: "ManualDocuments",
                column: "SoftwareId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesItem_PurchaseOrderDocuments_PurchaseOrderDocId",
                table: "InvoicesItem",
                column: "PurchaseOrderDocId",
                principalTable: "PurchaseOrderDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
