using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace baseapi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regulars",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Small = table.Column<string>(type: "text", nullable: false),
                    Medium = table.Column<string>(type: "text", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regulars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trendings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Small = table.Column<string>(type: "text", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trendings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thumbnails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    RegularId = table.Column<string>(type: "text", nullable: false),
                    TrendingId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thumbnails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Thumbnails_Regulars_RegularId",
                        column: x => x.RegularId,
                        principalTable: "Regulars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Thumbnails_Trendings_TrendingId",
                        column: x => x.TrendingId,
                        principalTable: "Trendings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Selections",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<string>(type: "text", nullable: false),
                    IsBookmarked = table.Column<bool>(type: "boolean", nullable: false),
                    IsTrending = table.Column<bool>(type: "boolean", nullable: false),
                    ThumbnailId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Selections_Thumbnails_ThumbnailId",
                        column: x => x.ThumbnailId,
                        principalTable: "Thumbnails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Selections_ThumbnailId",
                table: "Selections",
                column: "ThumbnailId");

            migrationBuilder.CreateIndex(
                name: "IX_Thumbnails_RegularId",
                table: "Thumbnails",
                column: "RegularId");

            migrationBuilder.CreateIndex(
                name: "IX_Thumbnails_TrendingId",
                table: "Thumbnails",
                column: "TrendingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Selections");

            migrationBuilder.DropTable(
                name: "Thumbnails");

            migrationBuilder.DropTable(
                name: "Regulars");

            migrationBuilder.DropTable(
                name: "Trendings");
        }
    }
}
