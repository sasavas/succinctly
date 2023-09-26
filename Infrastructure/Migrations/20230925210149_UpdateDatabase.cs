using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_open_question_topic_tags_topic_tag_tags_id",
                table: "open_question_topic_tags");

            migrationBuilder.DropForeignKey(
                name: "fk_open_questions_user_user_id",
                table: "open_questions");

            migrationBuilder.DropForeignKey(
                name: "fk_questionnaire_topic_tags_topic_tag_tags_id",
                table: "questionnaire_topic_tags");

            migrationBuilder.DropForeignKey(
                name: "fk_questionnaires_user_user_id",
                table: "questionnaires");

            migrationBuilder.DropForeignKey(
                name: "fk_user_open_question_likes_user_users_id",
                table: "user_open_question_likes");

            migrationBuilder.DropForeignKey(
                name: "fk_user_questionnaire_likes_user_users_id",
                table: "user_questionnaire_likes");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "pk_topic_tag",
                table: "topic_tag");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "topic_tag",
                newName: "topic_tags");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_topic_tags",
                table: "topic_tags",
                column: "id");

            migrationBuilder.CreateTable(
                name: "char_limit_options",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    char_limit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_char_limit_options", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "fk_open_question_topic_tags_topic_tags_tags_id",
                table: "open_question_topic_tags",
                column: "tags_id",
                principalTable: "topic_tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_open_questions_users_user_id",
                table: "open_questions",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_questionnaire_topic_tags_topic_tags_tags_id",
                table: "questionnaire_topic_tags",
                column: "tags_id",
                principalTable: "topic_tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_questionnaires_users_user_id",
                table: "questionnaires",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_open_question_likes_users_users_id",
                table: "user_open_question_likes",
                column: "users_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_questionnaire_likes_users_users_id",
                table: "user_questionnaire_likes",
                column: "users_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_open_question_topic_tags_topic_tags_tags_id",
                table: "open_question_topic_tags");

            migrationBuilder.DropForeignKey(
                name: "fk_open_questions_users_user_id",
                table: "open_questions");

            migrationBuilder.DropForeignKey(
                name: "fk_questionnaire_topic_tags_topic_tags_tags_id",
                table: "questionnaire_topic_tags");

            migrationBuilder.DropForeignKey(
                name: "fk_questionnaires_users_user_id",
                table: "questionnaires");

            migrationBuilder.DropForeignKey(
                name: "fk_user_open_question_likes_users_users_id",
                table: "user_open_question_likes");

            migrationBuilder.DropForeignKey(
                name: "fk_user_questionnaire_likes_users_users_id",
                table: "user_questionnaire_likes");

            migrationBuilder.DropTable(
                name: "char_limit_options");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_topic_tags",
                table: "topic_tags");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "topic_tags",
                newName: "topic_tag");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user",
                table: "user",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_topic_tag",
                table: "topic_tag",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_open_question_topic_tags_topic_tag_tags_id",
                table: "open_question_topic_tags",
                column: "tags_id",
                principalTable: "topic_tag",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_open_questions_user_user_id",
                table: "open_questions",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_questionnaire_topic_tags_topic_tag_tags_id",
                table: "questionnaire_topic_tags",
                column: "tags_id",
                principalTable: "topic_tag",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_questionnaires_user_user_id",
                table: "questionnaires",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_open_question_likes_user_users_id",
                table: "user_open_question_likes",
                column: "users_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_questionnaire_likes_user_users_id",
                table: "user_questionnaire_likes",
                column: "users_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
