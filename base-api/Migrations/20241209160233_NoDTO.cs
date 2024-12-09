using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace baseapi.Migrations
{
    /// <inheritdoc />
    public partial class NoDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Thumbnail_trending_large",
                table: "Selections");

            migrationBuilder.DropColumn(
                name: "Thumbnail_trending_small",
                table: "Selections");

            migrationBuilder.AddColumn<int>(
                name: "ThumbnailId",
                table: "Selections",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Regular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Small = table.Column<string>(type: "text", nullable: false),
                    Medium = table.Column<string>(type: "text", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trending",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Small = table.Column<string>(type: "text", nullable: true),
                    Large = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trending", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thumbnail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegularId = table.Column<int>(type: "integer", nullable: false),
                    TrendingId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thumbnail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Thumbnail_Regular_RegularId",
                        column: x => x.RegularId,
                        principalTable: "Regular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Thumbnail_Trending_TrendingId",
                        column: x => x.TrendingId,
                        principalTable: "Trending",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Selections_ThumbnailId",
                table: "Selections",
                column: "ThumbnailId");

            migrationBuilder.CreateIndex(
                name: "IX_Thumbnail_RegularId",
                table: "Thumbnail",
                column: "RegularId");

            migrationBuilder.CreateIndex(
                name: "IX_Thumbnail_TrendingId",
                table: "Thumbnail",
                column: "TrendingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Selections_Thumbnail_ThumbnailId",
                table: "Selections",
                column: "ThumbnailId",
                principalTable: "Thumbnail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Selections_Thumbnail_ThumbnailId",
                table: "Selections");

            migrationBuilder.DropTable(
                name: "Thumbnail");

            migrationBuilder.DropTable(
                name: "Regular");

            migrationBuilder.DropTable(
                name: "Trending");

            migrationBuilder.DropIndex(
                name: "IX_Selections_ThumbnailId",
                table: "Selections");

            migrationBuilder.DropColumn(
                name: "ThumbnailId",
                table: "Selections");

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

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail_trending_large",
                table: "Selections",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail_trending_small",
                table: "Selections",
                type: "text",
                nullable: true);
        }
    }
}
