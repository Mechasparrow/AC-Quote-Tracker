using Microsoft.EntityFrameworkCore.Migrations;

namespace ACQuoteTracker.Migrations
{
    public partial class FirstMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villagers",
                columns: table => new
                {
                    VillagerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villagers", x => x.VillagerId);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VillagerId = table.Column<int>(nullable: false),
                    QuoteText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                    table.ForeignKey(
                        name: "FK_Quotes_Villagers_VillagerId",
                        column: x => x.VillagerId,
                        principalTable: "Villagers",
                        principalColumn: "VillagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_VillagerId",
                table: "Quotes",
                column: "VillagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Villagers");
        }
    }
}
