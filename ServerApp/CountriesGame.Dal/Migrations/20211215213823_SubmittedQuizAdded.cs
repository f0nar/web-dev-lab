using Microsoft.EntityFrameworkCore.Migrations;

namespace CountriesGame.Dal.Migrations
{
    public partial class SubmittedQuizAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Questions");

            migrationBuilder.CreateTable(
                name: "SubmittedQuizzes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuizId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittedQuizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmittedQuizzes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubmittedQuizzes_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubmittedQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubmittedQuizId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittedQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmittedQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmittedQuestions_SubmittedQuizzes_SubmittedQuizId",
                        column: x => x.SubmittedQuizId,
                        principalTable: "SubmittedQuizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubmittedOptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MatchContent = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubmittedQuestionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittedOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmittedOptions_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubmittedOptions_SubmittedQuestions_SubmittedQuestionId",
                        column: x => x.SubmittedQuestionId,
                        principalTable: "SubmittedQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedOptions_OptionId",
                table: "SubmittedOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedOptions_SubmittedQuestionId",
                table: "SubmittedOptions",
                column: "SubmittedQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedQuestions_QuestionId",
                table: "SubmittedQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedQuestions_SubmittedQuizId",
                table: "SubmittedQuestions",
                column: "SubmittedQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedQuizzes_QuizId",
                table: "SubmittedQuizzes",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedQuizzes_UserId",
                table: "SubmittedQuizzes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubmittedOptions");

            migrationBuilder.DropTable(
                name: "SubmittedQuestions");

            migrationBuilder.DropTable(
                name: "SubmittedQuizzes");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
