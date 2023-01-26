using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippeeAPI.Migrations
{
    /// <inheritdoc />
    public partial class testmigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Naf_Sections",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naf_Sections", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    siren = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idnaf = table.Column<int>(name: "id_naf", type: "int", nullable: true),
                    street = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cp = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    legalform = table.Column<string>(name: "legal_form", type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    effective = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    website = table.Column<string>(name: "web_site", type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    payment = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.siren);
                    table.ForeignKey(
                        name: "FK_Companies_Naf_Sections_id_naf",
                        column: x => x.idnaf,
                        principalTable: "Naf_Sections",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Naf_Divisions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idnaf = table.Column<int>(name: "id_naf", type: "int", nullable: true),
                    title = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naf_Divisions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Naf_Divisions_Naf_Sections_id_naf",
                        column: x => x.idnaf,
                        principalTable: "Naf_Sections",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fristname = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    picture = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isonline = table.Column<bool>(name: "is_online", type: "tinyint(1)", nullable: true),
                    typeuser = table.Column<int>(name: "type_user", type: "int", nullable: true),
                    description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    website = table.Column<string>(name: "web_site", type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cv = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    idcompany = table.Column<int>(name: "id_company", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Companies_id_company",
                        column: x => x.idcompany,
                        principalTable: "Companies",
                        principalColumn: "siren");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idnafdivision = table.Column<int>(name: "id_naf_division", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Jobs_Naf_Divisions_id_naf_division",
                        column: x => x.idnafdivision,
                        principalTable: "Naf_Divisions",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SkillUser",
                columns: table => new
                {
                    skillid = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillUser", x => new { x.skillid, x.userid });
                    table.ForeignKey(
                        name: "FK_SkillUser_Skills_skillid",
                        column: x => x.skillid,
                        principalTable: "Skills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillUser_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Annoucement_Companies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idrecruiter = table.Column<int>(name: "id_recruiter", type: "int", nullable: true),
                    title = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    publishdate = table.Column<DateTime>(name: "publish_date", type: "datetime(6)", nullable: true),
                    idjob = table.Column<int>(name: "id_job", type: "int", nullable: true),
                    idnafdivision = table.Column<int>(name: "id_naf_division", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annoucement_Companies", x => x.id);
                    table.ForeignKey(
                        name: "FK_Annoucement_Companies_Jobs_id_job",
                        column: x => x.idjob,
                        principalTable: "Jobs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Annoucement_Companies_Naf_Divisions_id_naf_division",
                        column: x => x.idnafdivision,
                        principalTable: "Naf_Divisions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Annoucement_Companies_Users_id_recruiter",
                        column: x => x.idrecruiter,
                        principalTable: "Users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Annoucement_Students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idstudent = table.Column<int>(name: "id_student", type: "int", nullable: true),
                    title = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    publishdate = table.Column<DateTime>(name: "publish_date", type: "datetime(6)", nullable: true),
                    idjob = table.Column<int>(name: "id_job", type: "int", nullable: true),
                    idnafdivision = table.Column<int>(name: "id_naf_division", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annoucement_Students", x => x.id);
                    table.ForeignKey(
                        name: "FK_Annoucement_Students_Jobs_id_job",
                        column: x => x.idjob,
                        principalTable: "Jobs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Annoucement_Students_Naf_Divisions_id_naf_division",
                        column: x => x.idnafdivision,
                        principalTable: "Naf_Divisions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Annoucement_Students_Users_id_student",
                        column: x => x.idstudent,
                        principalTable: "Users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    AnnoucementCompanyid = table.Column<int>(name: "Annoucement_Companyid", type: "int", nullable: false),
                    Skillid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => new { x.AnnoucementCompanyid, x.Skillid });
                    table.ForeignKey(
                        name: "FK_Qualifications_Annoucement_Companies_Annoucement_Companyid",
                        column: x => x.AnnoucementCompanyid,
                        principalTable: "Annoucement_Companies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Qualifications_Skills_Skillid",
                        column: x => x.Skillid,
                        principalTable: "Skills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucement_Companies_id_job",
                table: "Annoucement_Companies",
                column: "id_job");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucement_Companies_id_naf_division",
                table: "Annoucement_Companies",
                column: "id_naf_division");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucement_Companies_id_recruiter",
                table: "Annoucement_Companies",
                column: "id_recruiter");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucement_Students_id_job",
                table: "Annoucement_Students",
                column: "id_job");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucement_Students_id_naf_division",
                table: "Annoucement_Students",
                column: "id_naf_division");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucement_Students_id_student",
                table: "Annoucement_Students",
                column: "id_student");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_id_naf",
                table: "Companies",
                column: "id_naf");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_id_naf_division",
                table: "Jobs",
                column: "id_naf_division");

            migrationBuilder.CreateIndex(
                name: "IX_Naf_Divisions_id_naf",
                table: "Naf_Divisions",
                column: "id_naf");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_Skillid",
                table: "Qualifications",
                column: "Skillid");

            migrationBuilder.CreateIndex(
                name: "IX_SkillUser_userid",
                table: "SkillUser",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_id_company",
                table: "Users",
                column: "id_company");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annoucement_Students");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "SkillUser");

            migrationBuilder.DropTable(
                name: "Annoucement_Companies");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Naf_Divisions");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Naf_Sections");
        }
    }
}
