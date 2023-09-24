﻿// <auto-generated />
using System;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(SuccinctlyContext))]
    [Migration("20230924101005_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Features.QuestionFeature.OpenQuestion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("question_text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_open_questions");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_open_questions_user_id");

                    b.ToTable("open_questions", (string)null);
                });

            modelBuilder.Entity("Domain.Features.QuestionnaireFeature.Questionnaire", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("question_text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_questionnaires");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_questionnaires_user_id");

                    b.ToTable("questionnaires", (string)null);
                });

            modelBuilder.Entity("Domain.Features.TagFeature.QuestionTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("TagText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("tag_text");

                    b.HasKey("Id")
                        .HasName("pk_question_tag");

                    b.ToTable("question_tag", (string)null);
                });

            modelBuilder.Entity("Domain.Features.UserFeature.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("OpenQuestionQuestionTag", b =>
                {
                    b.Property<long>("OpenQuestionsId")
                        .HasColumnType("bigint")
                        .HasColumnName("open_questions_id");

                    b.Property<int>("TagsId")
                        .HasColumnType("integer")
                        .HasColumnName("tags_id");

                    b.HasKey("OpenQuestionsId", "TagsId")
                        .HasName("pk_open_question_question_tag");

                    b.HasIndex("TagsId")
                        .HasDatabaseName("ix_open_question_question_tag_tags_id");

                    b.ToTable("open_question_question_tag", (string)null);
                });

            modelBuilder.Entity("OpenQuestionUser", b =>
                {
                    b.Property<long>("OpenQuestionId")
                        .HasColumnType("bigint")
                        .HasColumnName("open_question_id");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid")
                        .HasColumnName("users_id");

                    b.HasKey("OpenQuestionId", "UsersId")
                        .HasName("pk_user_open_question_likes");

                    b.HasIndex("UsersId")
                        .HasDatabaseName("ix_user_open_question_likes_users_id");

                    b.ToTable("user_open_question_likes", (string)null);
                });

            modelBuilder.Entity("QuestionTagQuestionnaire", b =>
                {
                    b.Property<long>("QuestionnairesId")
                        .HasColumnType("bigint")
                        .HasColumnName("questionnaires_id");

                    b.Property<int>("TagsId")
                        .HasColumnType("integer")
                        .HasColumnName("tags_id");

                    b.HasKey("QuestionnairesId", "TagsId")
                        .HasName("pk_question_tag_questionnaire");

                    b.HasIndex("TagsId")
                        .HasDatabaseName("ix_question_tag_questionnaire_tags_id");

                    b.ToTable("question_tag_questionnaire", (string)null);
                });

            modelBuilder.Entity("QuestionnaireUser", b =>
                {
                    b.Property<long>("QuestionnaireId")
                        .HasColumnType("bigint")
                        .HasColumnName("questionnaire_id");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid")
                        .HasColumnName("users_id");

                    b.HasKey("QuestionnaireId", "UsersId")
                        .HasName("pk_user_questionnaire_likes");

                    b.HasIndex("UsersId")
                        .HasDatabaseName("ix_user_questionnaire_likes_users_id");

                    b.ToTable("user_questionnaire_likes", (string)null);
                });

            modelBuilder.Entity("Domain.Features.QuestionFeature.OpenQuestion", b =>
                {
                    b.HasOne("Domain.Features.UserFeature.User", "User")
                        .WithMany("OpenQuestions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_open_questions_user_user_id");

                    b.OwnsMany("Domain.Features.QuestionFeature.OpenAnswer", "Answers", b1 =>
                        {
                            b1.Property<long>("QuestionId")
                                .HasColumnType("bigint")
                                .HasColumnName("question_id");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasColumnName("id");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<long>("Id"));

                            b1.Property<string>("AnswerText")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("answer_text");

                            b1.HasKey("QuestionId", "Id")
                                .HasName("pk_open_answer");

                            b1.ToTable("open_answer", (string)null);

                            b1.WithOwner("Question")
                                .HasForeignKey("QuestionId")
                                .HasConstraintName("fk_open_answer_open_questions_question_id");

                            b1.Navigation("Question");
                        });

                    b.Navigation("Answers");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Features.QuestionnaireFeature.Questionnaire", b =>
                {
                    b.HasOne("Domain.Features.UserFeature.User", "User")
                        .WithMany("Questionnaires")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_questionnaires_user_user_id");

                    b.OwnsMany("Domain.Features.QuestionnaireFeature.QuestionnaireOption", "QuestionnaireOptions", b1 =>
                        {
                            b1.Property<long>("QuestionnaireId")
                                .HasColumnType("bigint")
                                .HasColumnName("questionnaire_id");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasColumnName("id");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("value");

                            b1.HasKey("QuestionnaireId", "Id")
                                .HasName("pk_questionnaire_option");

                            b1.ToTable("questionnaire_option", (string)null);

                            b1.WithOwner("Questionnaire")
                                .HasForeignKey("QuestionnaireId")
                                .HasConstraintName("fk_questionnaire_option_questionnaires_questionnaire_id");

                            b1.Navigation("Questionnaire");
                        });

                    b.Navigation("QuestionnaireOptions");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OpenQuestionQuestionTag", b =>
                {
                    b.HasOne("Domain.Features.QuestionFeature.OpenQuestion", null)
                        .WithMany()
                        .HasForeignKey("OpenQuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_open_question_question_tag_open_questions_open_questions_id");

                    b.HasOne("Domain.Features.TagFeature.QuestionTag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_open_question_question_tag_question_tag_tags_id");
                });

            modelBuilder.Entity("OpenQuestionUser", b =>
                {
                    b.HasOne("Domain.Features.QuestionFeature.OpenQuestion", null)
                        .WithMany()
                        .HasForeignKey("OpenQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_open_question_likes_open_questions_open_question_id");

                    b.HasOne("Domain.Features.UserFeature.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_open_question_likes_user_users_id");
                });

            modelBuilder.Entity("QuestionTagQuestionnaire", b =>
                {
                    b.HasOne("Domain.Features.QuestionnaireFeature.Questionnaire", null)
                        .WithMany()
                        .HasForeignKey("QuestionnairesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_question_tag_questionnaire_questionnaires_questionnaires_id");

                    b.HasOne("Domain.Features.TagFeature.QuestionTag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_question_tag_questionnaire_question_tag_tags_id");
                });

            modelBuilder.Entity("QuestionnaireUser", b =>
                {
                    b.HasOne("Domain.Features.QuestionnaireFeature.Questionnaire", null)
                        .WithMany()
                        .HasForeignKey("QuestionnaireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_questionnaire_likes_questionnaires_questionnaire_id");

                    b.HasOne("Domain.Features.UserFeature.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_questionnaire_likes_user_users_id");
                });

            modelBuilder.Entity("Domain.Features.UserFeature.User", b =>
                {
                    b.Navigation("OpenQuestions");

                    b.Navigation("Questionnaires");
                });
#pragma warning restore 612, 618
        }
    }
}