using Microsoft.EntityFrameworkCore.Migrations;

namespace ACQuoteTracker.Migrations
{
    public partial class VillagerAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "VillagerName",
                table: "Quotes");

            migrationBuilder.AddColumn<int>(
                name: "VillagerId",
                table: "Quotes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Villager",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villager", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_VillagerId",
                table: "Quotes",
                column: "VillagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Villager_VillagerId",
                table: "Quotes",
                column: "VillagerId",
                principalTable: "Villager",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Villager_VillagerId",
                table: "Quotes");

            migrationBuilder.DropTable(
                name: "Villager");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_VillagerId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "VillagerId",
                table: "Quotes");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Quotes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VillagerName",
                table: "Quotes",
                type: "TEXT",
                nullable: true);
        }
    }
}
