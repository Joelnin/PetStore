using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetStore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Breed = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Age", "Breed", "Category", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, 3, "Golden Retriever", "dogs", "Friendly, loyal, and ready for a home.", "https://raw.githubusercontent.com/vsyang/pet-images/main/goldenr.jpg", "Max" },
                    { 2, 2, "Siamese", "cats", "Curious, calm, and full of personality.", "https://raw.githubusercontent.com/vsyang/pet-images/main/siamese.jpg", "Luna" },
                    { 3, 100, "Mini Flame", "dragons", "Magical companion with fiery charm.", "https://raw.githubusercontent.com/vsyang/pet-images/main/toothless.jpg", "Toothless" },
                    { 4, 5, "Silver Mane", "unicorns", "Rare, graceful, and full of wonder.", "https://raw.githubusercontent.com/vsyang/pet-images/main/unicorn.jpg", "Sparkle" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");
        }
    }
}
