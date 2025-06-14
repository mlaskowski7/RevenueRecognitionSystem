using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RevenueRecognitionSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SoftDeleteOnlyOnIndividualClients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "clients");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedAt",
                table: "individual_clients",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "individual_clients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "individual_clients");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "individual_clients");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "clients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
