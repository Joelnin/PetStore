using System;
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
                name: "ApplicationForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShelterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HelpType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HousingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherPets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FosterLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonthlyAmount = table.Column<int>(type: "int", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgreeToTerms = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YearOfBirth = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Energy = table.Column<int>(type: "int", nullable: false),
                    Is_Friendly = table.Column<bool>(type: "bit", nullable: false),
                    Is_Adopt = table.Column<bool>(type: "bit", nullable: false),
                    Is_Foster = table.Column<bool>(type: "bit", nullable: false),
                    Shelter_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shelters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationForms",
                columns: new[] { "Id", "Address", "AgreeToTerms", "Email", "Experience", "FosterLength", "FullName", "HelpType", "HousingStatus", "MonthlyAmount", "OtherPets", "PetName", "PhoneNumber", "Reason", "ShelterName", "SubmittedAt" },
                values: new object[,]
                {
                    { 1, "123 Main St, City, State, 12345", false, "john@example.com", null, null, "John Doe", "Adopt", null, null, null, "Max", "555-123-4567", null, "Golden Paws Rescue", new DateTime(2026, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "123 Main St, City, State, 12345", false, "jane@example.com", null, null, "Jane Smith", "Foster", null, null, null, "Majesty", "555-567-8901", null, "Whisker Haven", new DateTime(2026, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PetCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "dogs" },
                    { 2, "cats" },
                    { 3, "rabbits" },
                    { 4, "birds" },
                    { 5, "exotics" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Breed", "Description", "Energy", "ImageUrl", "Is_Adopt", "Is_Foster", "Is_Friendly", "Name", "Shelter_id", "Type", "YearOfBirth" },
                values: new object[,]
                {
                    { "1", "Golden Retriever", "Friendly, loyal, and ready for a home.", 4, "https://raw.githubusercontent.com/vsyang/pet-images/main/goldenr.jpg", true, true, true, "Max", "SHELTER-01", "dogs", 2021 },
                    { "10", "Ferret", "Only wants to be by you and follow you everywhere.", 4, "https://raw.githubusercontent.com/vsyang/pet-images/main/ferret.jpg", true, false, true, "Squishy", "SHELTER-06", "exotics", 2025 },
                    { "11", "Sugar Glider", "Comes out and plays all night.", 3, "https://raw.githubusercontent.com/vsyang/pet-images/main/sugar-glider.jpg", true, false, true, "Sweety", "SHELTER-04", "exotics", 2024 },
                    { "2", "Persian", "Curious, calm, and full of personality.", 3, "https://raw.githubusercontent.com/vsyang/pet-images/main/persian.jpg", true, false, true, "Majesty", "SHELTER-02", "cats", 2022 },
                    { "3", "Netherland Dwarf", "Magical companion with fiery charm.", 5, "https://raw.githubusercontent.com/vsyang/pet-images/main/netherland-dwarf.jpg", false, true, true, "Tiny", "SHELTER-06", "rabbits", 2010 },
                    { "4", "Hedgehog", "Rare, shy, and full of wonder.", 2, "https://raw.githubusercontent.com/vsyang/pet-images/main/hedgehog.jpg", true, true, true, "Sparkle", "SHELTER-04", "exotics", 2019 },
                    { "5", "Maltese", "Intelligent and handsome. He just loves to be with you.", 3, "https://raw.githubusercontent.com/vsyang/pet-images/main/maltese.jpg", true, true, true, "Cloud", "SHELTER-01", "dogs", 2023 },
                    { "6", "Bearded Dragon", "Curious, adorable, and intelligent.", 2, "https://raw.githubusercontent.com/vsyang/pet-images/main/bearded-dragon.jpg", false, false, false, "Jimbo", "SHELTER-05", "exotics", 2020 },
                    { "7", "Orange Tabby", "Majestic, regal, and content. All she wants is to lay in the sun.", 5, "https://raw.githubusercontent.com/vsyang/pet-images/main/orange-cat.jpg", false, false, true, "Raja", "SHELTER-02", "cats", 2017 },
                    { "8", "White Cockatoo", "Loves to talk, sing, and dance.", 5, "https://raw.githubusercontent.com/vsyang/pet-images/main/white-parrot.jpg", true, true, true, "Marshmallow", "SHELTER-03", "birds", 2014 },
                    { "9", "Parrot", "He's a living rainforest ready to go home with you.", 5, "https://raw.githubusercontent.com/vsyang/pet-images/main/parrot.jpg", true, true, true, "Sir Zir", "SHELTER-03", "birds", 2022 }
                });

            migrationBuilder.InsertData(
                table: "Shelters",
                columns: new[] { "Id", "City", "Country", "Email", "Name", "Phone", "State", "User_id" },
                values: new object[,]
                {
                    { "SHELTER-01", null, "US", "contact@goldenpawsrescue.org", "Golden Paws Rescue", null, "Pennsylvania", "user_01" },
                    { "SHELTER-02", null, "CA", "hello@whiskerhaven.org", "Whisker Haven", null, "Ontario", "user_02" },
                    { "SHELTER-03", null, "AU", "info@safewingssanctuary.org", "Safe Wings Sanctuary", null, "New South Wales", "user_03" },
                    { "SHELTER-04", null, "VE", "support@cloudinthesky.org", "Cloud in the Sky", null, "Mérida", "user_04" },
                    { "SHELTER-05", null, "ZA", "team@wildheartrefuge.org", "Wild Heart Refuge", null, "Western Cape", "user_05" },
                    { "SHELTER-06", null, "MX", "care@hopetailsshelter.org", "Hope Tails Shelter", null, "Guanajuato", "user_06" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationForms");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PetCategories");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Shelters");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
