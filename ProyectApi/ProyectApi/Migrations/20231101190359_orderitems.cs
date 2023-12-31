﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectApi.Migrations
{
    /// <inheritdoc />
    public partial class orderitems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "OrderItems");
        }
    }
}
