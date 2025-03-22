using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BilgeAdamBanka.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCardInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryYear = table.Column<int>(type: "int", nullable: false),
                    ExpiryMonth = table.Column<int>(type: "int", nullable: false),
                    CardLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCardInfos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserCardInfos",
                columns: new[] { "Id", "Balance", "CVC", "CardLimit", "CardNumber", "CardUserName", "CreatedDate", "DeletedDate", "ExpiryMonth", "ExpiryYear", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 8600m, "123", 8600m, "1234567890123456", "John Doe", new DateTime(2025, 3, 21, 20, 9, 9, 967, DateTimeKind.Local).AddTicks(1825), null, 11, 2025, 1, null },
                    { 2, 5000m, "321", 5000m, "9876543210987654", "Jane Doe", new DateTime(2025, 3, 21, 20, 9, 9, 968, DateTimeKind.Local).AddTicks(1762), null, 10, 2023, 1, null },
                    { 3, 4000m, "601", 4000m, "4111111111111111", "Kevin Nea", new DateTime(2025, 3, 21, 20, 9, 9, 968, DateTimeKind.Local).AddTicks(1768), null, 1, 2023, 1, null },
                    { 4, 3200m, "922", 3200m, "5555555555554444", "Sue Mayre", new DateTime(2025, 3, 21, 20, 9, 9, 968, DateTimeKind.Local).AddTicks(1770), null, 6, 2023, 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCardInfos");
        }
    }
}
