﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlgebraWebshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderStatusAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Order");
        }
    }
}
