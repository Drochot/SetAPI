using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SetAPI.Migrations
{
    /// <inheritdoc />
    public partial class SetsOnBoardMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SetsOnBoard",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SetsOnBoard",
                table: "Games");
        }
    }
}
