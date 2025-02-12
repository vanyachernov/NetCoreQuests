using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quests.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCorrectOptionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_questions_options_correct_option_id",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "fk_questions_options_correct_option_id1",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "ix_questions_correct_option_id1",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "correct_option_id1",
                table: "questions");

            migrationBuilder.AddForeignKey(
                name: "fk_questions_options_correct_option_id",
                table: "questions",
                column: "correct_option_id",
                principalTable: "options",
                principalColumn: "option_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_questions_options_correct_option_id",
                table: "questions");

            migrationBuilder.AddColumn<Guid>(
                name: "correct_option_id1",
                table: "questions",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_questions_correct_option_id1",
                table: "questions",
                column: "correct_option_id1");

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
    }
}
