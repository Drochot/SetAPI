using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SetAPI.Migrations
{
    /// <inheritdoc />
    public partial class FoundSetsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoundSets",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoundSets",
                table: "Games");
        }
    }
}
