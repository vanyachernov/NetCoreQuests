using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quests.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOptionsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_option_questions_question_id",
                table: "option");

            migrationBuilder.DropForeignKey(
                name: "fk_questions_option_correct_option_id",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "fk_questions_option_correct_option_id1",
                table: "questions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_option",
                table: "option");

            migrationBuilder.RenameTable(
                name: "option",
                newName: "options");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "options",
                newName: "option_id");

            migrationBuilder.RenameIndex(
                name: "ix_option_question_id",
                table: "options",
                newName: "ix_options_question_id");

            migrationBuilder.AlterColumn<string>(
                name: "text",
                table: "options",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "pk_options",
                table: "options",
                column: "option_id");

            migrationBuilder.AddForeignKey(
                name: "fk_options_questions_question_id",
                table: "options",
                column: "question_id",
                principalTable: "questions",
                principalColumn: "question_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_questions_options_correct_option_id",
                table: "questions",
                column: "correct_option_id",
                principalTable: "options",
                principalColumn: "option_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_questions_options_correct_option_id1",
                table: "questions",
                column: "correct_option_id1",
                principalTable: "options",
                principalColumn: "option_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_options_questions_question_id",
                table: "options");

            migrationBuilder.DropForeignKey(
                name: "fk_questions_options_correct_option_id",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "fk_questions_options_correct_option_id1",
                table: "questions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_options",
                table: "options");

            migrationBuilder.RenameTable(
                name: "options",
                newName: "option");

            migrationBuilder.RenameColumn(
                name: "option_id",
                table: "option",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "ix_options_question_id",
                table: "option",
                newName: "ix_option_question_id");

            migrationBuilder.AlterColumn<string>(
                name: "text",
                table: "option",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "pk_option",
                table: "option",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_option_questions_question_id",
                table: "option",
                column: "question_id",
                principalTable: "questions",
                principalColumn: "question_id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
