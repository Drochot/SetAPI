﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SetAPI.Migrations
{
    /// <inheritdoc />
    public partial class CardsOnBoardMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardsOnBoard",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardsOnBoard",
                table: "Games");
        }
    }
}
