using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quests.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingAndDifficutly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "difficulty",
                table: "tests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "rating",
                table: "tests",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "difficulty",
                table: "tests");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "tests");
        }
    }
}
