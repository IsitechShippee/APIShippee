using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippeeAPI.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Annoucement_Status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annoucement_Status", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Effectives",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effectives", x => x.id);
                })
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
                name: "Type_Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Users", x => x.id);
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
                    picture = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    street = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cp = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    legalform = table.Column<string>(name: "legal_form", type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ideffective = table.Column<int>(name: "id_effective", type: "int", nullable: true),
                    website = table.Column<string>(name: "web_site", type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    payment = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.siren);
                    table.ForeignKey(
                        name: "FK_Companies_Effectives_id_effective",
                        column: x => x.ideffective,
                        principalTable: "Effectives",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Companies_Naf_Sections_id_naf",
                        column: x => x.idnaf,
                        principalTable: "Naf_Sections",
                        principalColumn: "id");
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
                    idnaf = table.Column<int>(name: "id_naf", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Jobs_Naf_Sections_id_naf",
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
                    idnafsection = table.Column<int>(name: "id_naf_section", type: "int", nullable: true),
                    title = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naf_Divisions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Naf_Divisions_Naf_Sections_id_naf_section",
                        column: x => x.idnafsection,
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
                    surname = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    firstname = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    picture = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isonline = table.Column<bool>(name: "is_online", type: "tinyint(1)", nullable: true),
                    idtypeuser = table.Column<int>(name: "id_type_user", type: "int", nullable: true),
                    description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    website = table.Column<string>(name: "web_site", type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cv = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cp = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    isconveyed = table.Column<bool>(name: "is_conveyed", type: "tinyint(1)", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Users_Type_Users_id_type_user",
                        column: x => x.idtypeuser,
                        principalTable: "Type_Users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Annoucements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Userid = table.Column<int>(type: "int", nullable: true),
                    iduser = table.Column<int>(name: "id_user", type: "int", nullable: true),
                    title = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    publishdate = table.Column<DateTime>(name: "publish_date", type: "datetime(6)", nullable: true),
                    idtype = table.Column<int>(name: "id_type", type: "int", nullable: true),
                    idstatus = table.Column<int>(name: "id_status", type: "int", nullable: true),
                    idnafdivision = table.Column<int>(name: "id_naf_division", type: "int", nullable: true),
                    idjob = table.Column<int>(name: "id_job", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annoucements", x => x.id);
                    table.ForeignKey(
                        name: "FK_Annoucements_Annoucement_Status_id_status",
                        column: x => x.idstatus,
                        principalTable: "Annoucement_Status",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Annoucements_Jobs_id_job",
                        column: x => x.idjob,
                        principalTable: "Jobs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Annoucements_Naf_Divisions_id_naf_division",
                        column: x => x.idnafdivision,
                        principalTable: "Naf_Divisions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Annoucements_Type_Users_id_type",
                        column: x => x.idtype,
                        principalTable: "Type_Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Annoucements_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Student_Skills",
                columns: table => new
                {
                    userid = table.Column<int>(name: "user_id", type: "int", nullable: false),
                    skillid = table.Column<int>(name: "skill_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Skills", x => new { x.userid, x.skillid });
                    table.ForeignKey(
                        name: "FK_Student_Skills_Skills_skill_id",
                        column: x => x.skillid,
                        principalTable: "Skills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Skills_Users_user_id",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_id_job",
                table: "Annoucements",
                column: "id_job");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_id_naf_division",
                table: "Annoucements",
                column: "id_naf_division");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_id_status",
                table: "Annoucements",
                column: "id_status");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_id_type",
                table: "Annoucements",
                column: "id_type");

            migrationBuilder.CreateIndex(
                name: "IX_Annoucements_Userid",
                table: "Annoucements",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_id_effective",
                table: "Companies",
                column: "id_effective");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_id_naf",
                table: "Companies",
                column: "id_naf");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_id_naf",
                table: "Jobs",
                column: "id_naf");

            migrationBuilder.CreateIndex(
                name: "IX_Naf_Divisions_id_naf_section",
                table: "Naf_Divisions",
                column: "id_naf_section");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Skills_skill_id",
                table: "Student_Skills",
                column: "skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_id_company",
                table: "Users",
                column: "id_company");

            migrationBuilder.CreateIndex(
                name: "IX_Users_id_type_user",
                table: "Users",
                column: "id_type_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annoucements");

            migrationBuilder.DropTable(
                name: "Student_Skills");

            migrationBuilder.DropTable(
                name: "Annoucement_Status");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Naf_Divisions");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Type_Users");

            migrationBuilder.DropTable(
                name: "Effectives");

            migrationBuilder.DropTable(
                name: "Naf_Sections");
        }
    }
}
