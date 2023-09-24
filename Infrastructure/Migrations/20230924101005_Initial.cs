using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "question_tag",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tag_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_question_tag", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "open_questions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_open_questions", x => x.id);
                    table.ForeignKey(
                        name: "fk_open_questions_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questionnaires",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_questionnaires", x => x.id);
                    table.ForeignKey(
                        name: "fk_questionnaires_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "open_answer",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    question_id = table.Column<long>(type: "bigint", nullable: false),
                    answer_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_open_answer", x => new { x.question_id, x.id });
                    table.ForeignKey(
                        name: "fk_open_answer_open_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "open_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "open_question_question_tag",
                columns: table => new
                {
                    open_questions_id = table.Column<long>(type: "bigint", nullable: false),
                    tags_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_open_question_question_tag", x => new { x.open_questions_id, x.tags_id });
                    table.ForeignKey(
                        name: "fk_open_question_question_tag_open_questions_open_questions_id",
                        column: x => x.open_questions_id,
                        principalTable: "open_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_open_question_question_tag_question_tag_tags_id",
                        column: x => x.tags_id,
                        principalTable: "question_tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_open_question_likes",
                columns: table => new
                {
                    open_question_id = table.Column<long>(type: "bigint", nullable: false),
                    users_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_open_question_likes", x => new { x.open_question_id, x.users_id });
                    table.ForeignKey(
                        name: "fk_user_open_question_likes_open_questions_open_question_id",
                        column: x => x.open_question_id,
                        principalTable: "open_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_open_question_likes_user_users_id",
                        column: x => x.users_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "question_tag_questionnaire",
                columns: table => new
                {
                    questionnaires_id = table.Column<long>(type: "bigint", nullable: false),
                    tags_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_question_tag_questionnaire", x => new { x.questionnaires_id, x.tags_id });
                    table.ForeignKey(
                        name: "fk_question_tag_questionnaire_question_tag_tags_id",
                        column: x => x.tags_id,
                        principalTable: "question_tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_question_tag_questionnaire_questionnaires_questionnaires_id",
                        column: x => x.questionnaires_id,
                        principalTable: "questionnaires",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questionnaire_option",
                columns: table => new
                {
                    questionnaire_id = table.Column<long>(type: "bigint", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_questionnaire_option", x => new { x.questionnaire_id, x.id });
                    table.ForeignKey(
                        name: "fk_questionnaire_option_questionnaires_questionnaire_id",
                        column: x => x.questionnaire_id,
                        principalTable: "questionnaires",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_questionnaire_likes",
                columns: table => new
                {
                    questionnaire_id = table.Column<long>(type: "bigint", nullable: false),
                    users_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_questionnaire_likes", x => new { x.questionnaire_id, x.users_id });
                    table.ForeignKey(
                        name: "fk_user_questionnaire_likes_questionnaires_questionnaire_id",
                        column: x => x.questionnaire_id,
                        principalTable: "questionnaires",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_questionnaire_likes_user_users_id",
                        column: x => x.users_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_open_question_question_tag_tags_id",
                table: "open_question_question_tag",
                column: "tags_id");

            migrationBuilder.CreateIndex(
                name: "ix_open_questions_user_id",
                table: "open_questions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_question_tag_questionnaire_tags_id",
                table: "question_tag_questionnaire",
                column: "tags_id");

            migrationBuilder.CreateIndex(
                name: "ix_questionnaires_user_id",
                table: "questionnaires",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_open_question_likes_users_id",
                table: "user_open_question_likes",
                column: "users_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_questionnaire_likes_users_id",
                table: "user_questionnaire_likes",
                column: "users_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "open_answer");

            migrationBuilder.DropTable(
                name: "open_question_question_tag");

            migrationBuilder.DropTable(
                name: "question_tag_questionnaire");

            migrationBuilder.DropTable(
                name: "questionnaire_option");

            migrationBuilder.DropTable(
                name: "user_open_question_likes");

            migrationBuilder.DropTable(
                name: "user_questionnaire_likes");

            migrationBuilder.DropTable(
                name: "question_tag");

            migrationBuilder.DropTable(
                name: "open_questions");

            migrationBuilder.DropTable(
                name: "questionnaires");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
