using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructur.Migrations
{
    /// <inheritdoc />
    public partial class InitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_Exams_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "ExamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AnswerDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    OptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionText = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.OptionId);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[,]
                {
                    { 1, "گروه A" },
                    { 2, "گروه B" },
                    { 3, "گروه C" }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "ExamId", "Duration", "ExamName", "GroupId", "StartDate" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 1, 0, 0, 0), "امتحان ریاضی", 1, new DateTime(2024, 12, 1, 23, 38, 56, 901, DateTimeKind.Local).AddTicks(6374) },
                    { 2, new TimeSpan(0, 1, 0, 0, 0), "امتحان جغرافیا", 2, new DateTime(2024, 12, 2, 23, 38, 56, 901, DateTimeKind.Local).AddTicks(7223) },
                    { 3, new TimeSpan(0, 1, 0, 0, 0), "امتحان تاریخ", 3, new DateTime(2024, 12, 3, 23, 38, 56, 901, DateTimeKind.Local).AddTicks(7333) },
                    { 4, new TimeSpan(0, 1, 0, 0, 0), "امتحان شیمی", 1, new DateTime(2024, 12, 4, 23, 38, 56, 901, DateTimeKind.Local).AddTicks(7336) },
                    { 5, new TimeSpan(0, 1, 0, 0, 0), "امتحان مبانی علوم", 2, new DateTime(2024, 12, 5, 23, 38, 56, 901, DateTimeKind.Local).AddTicks(7338) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "GroupId", "StudentName" },
                values: new object[,]
                {
                    { 1, 1, "حسام" },
                    { 2, 1, "هما" },
                    { 3, 2, "مریم" },
                    { 4, 2, "حامد" },
                    { 5, 3, "حدیث" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "ExamId", "QuestionText" },
                values: new object[,]
                {
                    { 1, 1, "۲ + ۲ برابر با چیست؟" },
                    { 2, 2, "پایتخت فرانسه کجاست؟" },
                    { 3, 3, "چه کسی نمایشنامه 'هملت' را نوشت؟" },
                    { 4, 4, "نماد شیمیایی آب چیست؟" },
                    { 5, 5, "سرعت نور چقدر است؟" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "AnswerDate", "AnswerText", "QuestionId", "StudentId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 1, 23, 38, 56, 895, DateTimeKind.Local).AddTicks(63), "پاسخ 1", 1, 1 },
                    { 2, new DateTime(2024, 12, 1, 23, 38, 56, 895, DateTimeKind.Local).AddTicks(8756), "پاسخ 2", 2, 1 },
                    { 3, new DateTime(2024, 12, 1, 23, 38, 56, 895, DateTimeKind.Local).AddTicks(8765), "پاسخ 3", 3, 2 },
                    { 4, new DateTime(2024, 12, 1, 23, 38, 56, 895, DateTimeKind.Local).AddTicks(8766), "پاسخ 4", 4, 2 },
                    { 5, new DateTime(2024, 12, 1, 23, 38, 56, 895, DateTimeKind.Local).AddTicks(8767), "پاسخ 5", 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionId", "IsChecked", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { 1, true, "4", 1 },
                    { 2, false, "5", 1 },
                    { 3, true, "پاریس", 2 },
                    { 4, false, "لندن", 2 },
                    { 5, true, "شکسپیر", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_StudentId",
                table: "Answers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_GroupId",
                table: "Exams",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExamId",
                table: "Questions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
