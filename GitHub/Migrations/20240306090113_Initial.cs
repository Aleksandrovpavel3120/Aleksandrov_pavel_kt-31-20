using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GitHub.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_group",
                columns: table => new
                {
                    groupid = table.Column<int>(name: "group_id", type: "integer", nullable: false, comment: "Идентификатор записи группы")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cgroupname = table.Column<string>(name: "c_group_name", type: "varchar", maxLength: 100, nullable: false, comment: "Название группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_group_group_id", x => x.groupid);
                });

            migrationBuilder.CreateTable(
                name: "cd_ratings",
                columns: table => new
                {
                    ratingsid = table.Column<int>(name: "ratings_id", type: "integer", nullable: false, comment: "Идентификатор экзамена")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cratingsname = table.Column<string>(name: "c_ratings_name", type: "varchar", maxLength: 100, nullable: false, comment: "Название экзамена"),
                    cratingsgrade = table.Column<int>(name: "c_ratings_grade", type: "int4", maxLength: 100, nullable: false, comment: "Оценка")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_ratings_ratings_id", x => x.ratingsid);
                });

            migrationBuilder.CreateTable(
                name: "cd_test",
                columns: table => new
                {
                    testid = table.Column<int>(name: "test_id", type: "integer", nullable: false, comment: "Идентификатор зачета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ctestname = table.Column<string>(name: "c_test_name", type: "varchar", maxLength: 100, nullable: false, comment: "Название зачета"),
                    ctestist = table.Column<int>(name: "c_test_ist", type: "int4", maxLength: 100, nullable: false, comment: "Зачет или нет")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_test_test_id", x => x.testid);
                });

            migrationBuilder.CreateTable(
                name: "cd_student",
                columns: table => new
                {
                    studentid = table.Column<int>(name: "student_id", type: "integer", nullable: false, comment: "Идентификатор записи студента")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cstudentfirstname = table.Column<string>(name: "c_student_firstname", type: "varchar", maxLength: 100, nullable: false, comment: "Имя студента"),
                    cstudentlastname = table.Column<string>(name: "c_student_lastname", type: "varchar", maxLength: 100, nullable: false, comment: "Фамилия студента"),
                    cstudentmiddlename = table.Column<string>(name: "c_student_middlename", type: "varchar", maxLength: 100, nullable: false, comment: "Отчество студента"),
                    fgroupid = table.Column<int>(name: "f_group_id", type: "int4", nullable: false, comment: "Идентификатор группы"),
                    fratingsid = table.Column<int>(name: "f_ratings_id", type: "int4", nullable: false, comment: "Оценка"),
                    ftestid = table.Column<int>(name: "f_test_id", type: "int4", nullable: false, comment: "Зачет")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_student_student_id", x => x.studentid);
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.fgroupid,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_ratings_id",
                        column: x => x.fratingsid,
                        principalTable: "cd_ratings",
                        principalColumn: "ratings_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_test_id",
                        column: x => x.ftestid,
                        principalTable: "cd_test",
                        principalColumn: "test_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_student_fk_f_group_id",
                table: "cd_student",
                column: "f_group_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_student_fk_f_ratings_id",
                table: "cd_student",
                column: "f_ratings_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_student_fk_f_test_id",
                table: "cd_student",
                column: "f_test_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_student");

            migrationBuilder.DropTable(
                name: "cd_group");

            migrationBuilder.DropTable(
                name: "cd_ratings");

            migrationBuilder.DropTable(
                name: "cd_test");
        }
    }
}