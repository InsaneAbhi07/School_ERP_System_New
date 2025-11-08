using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_ErP.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Master_SchoolInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Web = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AffNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_SchoolInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_MasterClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wing = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_MasterClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_MasterFeeCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_MasterFeeCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_MasterHouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    House = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_MasterHouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_MasterSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sec = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_MasterSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_MasterStream",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stream = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_MasterStream", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_StudentRegistration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RollNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdmDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    APAARID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdmInClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    House = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stream = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DOBInWords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherQualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherQualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GuardianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuardianRelation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CasteCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AadharNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermPIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrPIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeeCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialCase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentQuota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMSNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdmissionCancelled = table.Column<bool>(type: "bit", nullable: false),
                    NotShow = table.Column<bool>(type: "bit", nullable: false),
                    StudentPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_StudentRegistration", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Master_SchoolInfo");

            migrationBuilder.DropTable(
                name: "Tbl_MasterClass");

            migrationBuilder.DropTable(
                name: "Tbl_MasterFeeCategory");

            migrationBuilder.DropTable(
                name: "Tbl_MasterHouse");

            migrationBuilder.DropTable(
                name: "Tbl_MasterSection");

            migrationBuilder.DropTable(
                name: "Tbl_MasterStream");

            migrationBuilder.DropTable(
                name: "Tbl_StudentRegistration");
        }
    }
}
