using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb3_AvanceradDotNet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_Interests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Links_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Daniel", "Johansson", "0703157383" },
                    { 2, "Sara", "Larsson", "0702456700" },
                    { 3, "Victor", "Svensson", "0765438976" }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "Description", "PersonId", "Title" },
                values: new object[,]
                {
                    { 1, "Skiing is a popular winter sport that involves sliding down snow-covered slopes on long, narrow boards called skis attached to boots. It's not just about gliding down the mountain; it's a dynamic blend of athleticism, technique, and connection with nature. Skiers use a combination of gravity, momentum, and their own muscle power to navigate various terrains, from gentle slopes to steep mountainsides", 1, "Skiing" },
                    { 2, "Chess is played by two opponents on a square board divided into 64 smaller squares of alternating colors, typically black and white. Each player starts with an identical set of 16 pieces: one king, one queen, two rooks, two knights, two bishops, and eight pawns. The objective of chess is to checkmate your opponent's king.", 1, "Chess" },
                    { 3, "Surfing is a water sport where individuals ride waves on a specially designed board, known as a surfboard, typically while standing up. Surfers paddle out into the ocean, waiting for the right wave to catch, and then use their skills to balance and maneuver on the moving water. It's a dynamic and exhilarating activity that requires coordination, strength, and a deep connection with the ocean. Surfers often describe the experience as a unique blend of adrenaline, tranquility, and freedom, making it a beloved pastime for enthusiasts around the world.", 2, "Surfing" },
                    { 4, "Sailing is a recreational or competitive activity that involves navigating a watercraft, typically a sailboat, across bodies of water using the power of the wind. Sailboats are equipped with sails, which harness the wind's force to propel the vessel forward. Sailors adjust the sails and steer the boat to catch the wind effectively and control its direction.", 2, "Sailing" },
                    { 5, "Programming is the art and science of instructing computers to perform specific tasks by writing sets of instructions, known as code, in various programming languages. It involves problem-solving, logical thinking, and creativity to design, develop, and debug software applications, websites, and digital systems. Programmers use their expertise to automate processes, create innovative solutions, and shape the digital world we interact with every day.", 3, "Programming" },
                    { 6, "Fishing is a recreational or commercial activity involving the pursuit and capture of aquatic life, typically fish, using various techniques such as angling, netting, or trapping. Anglers often employ rods, reels, and bait to lure fish, while commercial fishermen use specialized equipment like trawlers or longlines to catch fish in larger quantities. It's a timeless pastime enjoyed for relaxation, challenge, and sustenance, connecting individuals with nature and the bounty of the sea or freshwater environments.", 3, "Fishing" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkId", "InterestId", "URL" },
                values: new object[,]
                {
                    { 1, 1, "skidresor.se" },
                    { 2, 1, "skistar.com" },
                    { 3, 2, "chess.com" },
                    { 4, 3, "surfers.se" },
                    { 5, 3, "surfskolan.se" },
                    { 6, 4, "varbergssegelsallskap.se" },
                    { 7, 5, "codecademy.com" },
                    { 8, 5, "w3schools.com" },
                    { 9, 6, "swedenfishing.com" },
                    { 10, 6, "fladenfishing.se" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_PersonId",
                table: "Interests",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_InterestId",
                table: "Links",
                column: "InterestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
