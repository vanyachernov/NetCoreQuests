using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quests.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "options");

            migrationBuilder.DropColumn(
                name: "correct_option_text",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "is_correct",
                table: "questions");

            migrationBuilder.AlterColumn<Guid>(
                name: "correct_option_id",
                table: "questions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "correct_option_id1",
                table: "questions",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "option",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    is_correct = table.Column<bool>(type: "boolean", nullable: false),
                    question_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_option", x => x.id);
                    table.ForeignKey(
                        name: "fk_option_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_questions_correct_option_id",
                table: "questions",
                column: "correct_option_id");

            migrationBuilder.CreateIndex(
                name: "ix_questions_correct_option_id1",
                table: "questions",
                column: "correct_option_id1");

            migrationBuilder.CreateIndex(
                name: "ix_option_question_id",
                table: "option",
                column: "question_id");

            migrationBuilder.AddForeignKey(
                name: "fk_questions_option_correct_option_id",
                table: "questions",
                column: "correct_option_id",
                principalTable: "option",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_questions_option_correct_option_id1",
                table: "questions",
                column: "correct_option_id1",
                principalTable: "option",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_questions_option_correct_option_id",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "fk_questions_option_correct_option_id1",
                table: "questions");

            migrationBuilder.DropTable(
                name: "option");

            migrationBuilder.DropIndex(
                name: "ix_questions_correct_option_id",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "ix_questions_correct_option_id1",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "correct_option_id1",
                table: "questions");

            migrationBuilder.AlterColumn<Guid>(
                name: "correct_option_id",
                table: "questions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "correct_option_text",
                table: "questions",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "is_correct",
                table: "questions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "options",
                columns: table => new
                {
                    question_id = table.Column<Guid>(type: "uuid", nullable: false),
                    option_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_correct = table.Column<bool>(type: "boolean", nullable: false),
                    option_text = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_options", x => new { x.question_id, x.option_id });
                    table.ForeignKey(
                        name: "fk_options_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
