using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecurePass.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DigitalSecurityTipCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DigitalSecurityTipCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DigitalSecurityTips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodPractice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DynamicUpdateOfTip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DigitalSecurityTipCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DigitalSecurityTips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DigitalSecurityTips_DigitalSecurityTipCategories_DigitalSecurityTipCategoryId",
                        column: x => x.DigitalSecurityTipCategoryId,
                        principalTable: "DigitalSecurityTipCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DigitalSecurityTips_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasswordGenerations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasswordLength = table.Column<int>(type: "int", nullable: false),
                    IncludeUpperCaseLetter = table.Column<bool>(type: "bit", nullable: false),
                    IncludeLowerCaseLetter = table.Column<bool>(type: "bit", nullable: false),
                    IncludeNumber = table.Column<bool>(type: "bit", nullable: false),
                    IncludeSpecialCharacter = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordGenerations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordGenerations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasswordStrengthEvaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrengthLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoodOrBadAspect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuggestionMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordGenerationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordStrengthEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordStrengthEvaluations_PasswordGenerations_PasswordGenerationId",
                        column: x => x.PasswordGenerationId,
                        principalTable: "PasswordGenerations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PasswordStrengthEvaluations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DigitalSecurityTips_DigitalSecurityTipCategoryId",
                table: "DigitalSecurityTips",
                column: "DigitalSecurityTipCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DigitalSecurityTips_UserId",
                table: "DigitalSecurityTips",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordGenerations_UserId",
                table: "PasswordGenerations",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PasswordStrengthEvaluations_PasswordGenerationId",
                table: "PasswordStrengthEvaluations",
                column: "PasswordGenerationId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordStrengthEvaluations_UserId",
                table: "PasswordStrengthEvaluations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DigitalSecurityTips");

            migrationBuilder.DropTable(
                name: "PasswordStrengthEvaluations");

            migrationBuilder.DropTable(
                name: "DigitalSecurityTipCategories");

            migrationBuilder.DropTable(
                name: "PasswordGenerations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
