using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PuzzleId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Puzzles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puzzles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameGraphic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hints",
                columns: new[] { "Id", "Description", "Order", "PuzzleId" },
                values: new object[] { 1, "Sit on the chair!", 1, 1 });

            migrationBuilder.InsertData(
                table: "Puzzles",
                columns: new[] { "Id", "Description", "Name", "Order", "RoomId" },
                values: new object[] { 1, "Player must sit on the wizard's chair", "Sit on Chair", 1, 4 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Image", "Name", "NameGraphic" },
                values: new object[,]
                {
                    { 1, "https://paniqescaperoom.com/img/paniq/room-bg-the-time-machine-card-2.webp", "Time Machine", "https://paniqescaperoom.com/img/paniq/room-name-the-time-machine-2.png" },
                    { 2, "https://paniqescaperoom.com/img/paniq/room-bg-atlantis-rising-card-2.webp", "Atlantis", "https://paniqescaperoom.com/img/paniq/room-name-atlantis-rising-2.png" },
                    { 3, "https://paniqescaperoom.com/img/paniq/room-bg-haunted-manor-card-2.webp", "Haunted", "https://paniqescaperoom.com/img/paniq/room-name-haunted-manor-2.png" },
                    { 4, "https://paniqescaperoom.com/img/paniq/room-bg-wizard-trials-card-2.webp", "Wizard", "https://paniqescaperoom.com/img/paniq/room-name-wizard-trials-2.png" },
                    { 5, "https://paniqescaperoom.com/img/paniq/room-bg-zombie-outbreak-card-2.webp", "Zombie", "https://paniqescaperoom.com/img/paniq/room-name-zombie-outbreak-2.png" },
                    { 6, "https://paniqescaperoom.com/img/paniq/room-bg-casino-heist-card-2.webp", "Casino", "https://paniqescaperoom.com/img/paniq/room-name-casino-heist-2.png" },
                    { 7, "https://paniqescaperoom.com/img/paniq/room-bg-the-morning-after-card-2.webp", "Morning After", "https://paniqescaperoom.com/img/paniq/room-name-the-morning-after-2.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hints");

            migrationBuilder.DropTable(
                name: "Puzzles");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
