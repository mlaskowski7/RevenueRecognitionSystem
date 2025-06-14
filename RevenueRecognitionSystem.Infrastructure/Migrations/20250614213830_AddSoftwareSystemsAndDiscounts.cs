using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RevenueRecognitionSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftwareSystemsAndDiscounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "discounts",
                columns: table => new
                {
                    DiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discounts", x => x.DiscountId);
                    table.CheckConstraint("CK_Discount_Percentage_Range", "[Percentage] >= 1 AND [Percentage] <= 99");
                });

            migrationBuilder.CreateTable(
                name: "software_systems",
                columns: table => new
                {
                    SoftwareSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Version = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsSoldUpfront = table.Column<bool>(type: "bit", nullable: false),
                    IsSoldAsSubscription = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_software_systems", x => x.SoftwareSystemId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "discounts");

            migrationBuilder.DropTable(
                name: "software_systems");
        }
    }
}
