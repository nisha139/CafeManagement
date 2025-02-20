using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialAddedGuids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CafeMenus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifiedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deletedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isdeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CafeMenus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuItemIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    createdon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modifiedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deletedon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isdeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CafeMenus");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
