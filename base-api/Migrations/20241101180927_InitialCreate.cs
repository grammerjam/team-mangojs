using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace base_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regulars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Small = table.Column<string>(type: "text", nullable: false),
                    Medium = table.Column<string>(type: "text", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regulars", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trendings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Small = table.Column<string>(type: "text", nullable: false),
                    Large = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trendings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Thumbnails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegularID = table.Column<int>(type: "integer", nullable: false),
                    TrendingID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thumbnails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Thumbnails_Regulars_RegularID",
                        column: x => x.RegularID,
                        principalTable: "Regulars",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Thumbnails_Trendings_TrendingID",
                        column: x => x.TrendingID,
                        principalTable: "Trendings",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Selections",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<string>(type: "text", nullable: false),
                    IsBookmarked = table.Column<bool>(type: "boolean", nullable: false),
                    IsTrending = table.Column<bool>(type: "boolean", nullable: false),
                    ThumbnailID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selections", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Selections_Thumbnails_ThumbnailID",
                        column: x => x.ThumbnailID,
                        principalTable: "Thumbnails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Selections_ThumbnailID",
                table: "Selections",
                column: "ThumbnailID");

            migrationBuilder.CreateIndex(
                name: "IX_Thumbnails_RegularID",
                table: "Thumbnails",
                column: "RegularID");

            migrationBuilder.CreateIndex(
                name: "IX_Thumbnails_TrendingID",
                table: "Thumbnails",
                column: "TrendingID");
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
