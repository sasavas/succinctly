using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNamesAndRelationNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "open_question_question_tag");

            migrationBuilder.DropTable(
                name: "question_tag_questionnaire");

            migrationBuilder.DropTable(
                name: "question_tag");

            migrationBuilder.CreateTable(
                name: "topic_tag",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tag_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_topic_tag", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "open_question_topic_tags",
                columns: table => new
                {
                    open_questions_id = table.Column<long>(type: "bigint", nullable: false),
                    tags_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_open_question_topic_tags", x => new { x.open_questions_id, x.tags_id });
                    table.ForeignKey(
                        name: "fk_open_question_topic_tags_open_questions_open_questions_id",
                        column: x => x.open_questions_id,
                        principalTable: "open_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_open_question_topic_tags_topic_tag_tags_id",
                        column: x => x.tags_id,
                        principalTable: "topic_tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questionnaire_topic_tags",
                columns: table => new
                {
                    questionnaires_id = table.Column<long>(type: "bigint", nullable: false),
                    tags_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_questionnaire_topic_tags", x => new { x.questionnaires_id, x.tags_id });
                    table.ForeignKey(
                        name: "fk_questionnaire_topic_tags_questionnaires_questionnaires_id",
                        column: x => x.questionnaires_id,
                        principalTable: "questionnaires",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_questionnaire_topic_tags_topic_tag_tags_id",
                        column: x => x.tags_id,
                        principalTable: "topic_tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_open_question_topic_tags_tags_id",
                table: "open_question_topic_tags",
                column: "tags_id");

            migrationBuilder.CreateIndex(
                name: "ix_questionnaire_topic_tags_tags_id",
                table: "questionnaire_topic_tags",
                column: "tags_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "open_question_topic_tags");

            migrationBuilder.DropTable(
                name: "questionnaire_topic_tags");

            migrationBuilder.DropTable(
                name: "topic_tag");

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

            migrationBuilder.CreateIndex(
                name: "ix_open_question_question_tag_tags_id",
                table: "open_question_question_tag",
                column: "tags_id");

            migrationBuilder.CreateIndex(
                name: "ix_question_tag_questionnaire_tags_id",
                table: "question_tag_questionnaire",
                column: "tags_id");
        }
    }
}
