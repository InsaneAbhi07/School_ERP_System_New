using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_ErP.Migrations
{
    /// <inheritdoc />
    public partial class AddedCHequeBankField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "NotShow",
                table: "Tbl_StudentRegistration",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Tbl_StudentRegistration",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "AdmissionCancelled",
                table: "Tbl_StudentRegistration",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "EntryDate",
                table: "Tbl_FeeDeposite",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ChequeBank",
                table: "Tbl_FeeDeposite",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChequeBank",
                table: "Tbl_FeeDeposite");

            migrationBuilder.AlterColumn<bool>(
                name: "NotShow",
                table: "Tbl_StudentRegistration",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Tbl_StudentRegistration",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<bool>(
                name: "AdmissionCancelled",
                table: "Tbl_StudentRegistration",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EntryDate",
                table: "Tbl_FeeDeposite",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
