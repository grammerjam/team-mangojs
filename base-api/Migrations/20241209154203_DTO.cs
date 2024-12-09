using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace baseapi.Migrations
{
    /// <inheritdoc />
    public partial class DTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Regular_Large",
                table: "Selections");

            migrationBuilder.DropColumn(
                name: "Regular_Medium",
                table: "Selections");

            migrationBuilder.DropColumn(
                name: "Regular_Small",
                table: "Selections");

            migrationBuilder.RenameColumn(
                name: "Trending_Small",
                table: "Selections",
                newName: "Thumbnail_trending_small");

            migrationBuilder.RenameColumn(
                name: "Trending_Large",
                table: "Selections",
                newName: "Thumbnail_trending_large");

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail_regular_large",
                table: "Selections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail_regular_medium",
                table: "Selections",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail_regular_small",
                table: "Selections",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thumbnail_regular_large",
                table: "Selections");

            migrationBuilder.DropColumn(
                name: "Thumbnail_regular_medium",
                table: "Selections");

            migrationBuilder.DropColumn(
                name: "Thumbnail_regular_small",
                table: "Selections");

            migrationBuilder.RenameColumn(
                name: "Thumbnail_trending_small",
                table: "Selections",
                newName: "Trending_Small");

            migrationBuilder.RenameColumn(
                name: "Thumbnail_trending_large",
                table: "Selections",
                newName: "Trending_Large");

            migrationBuilder.AddColumn<string>(
                name: "Regular_Large",
                table: "Selections",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Regular_Medium",
                table: "Selections",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Regular_Small",
                table: "Selections",
                type: "text",
                nullable: true);
        }
    }
}
