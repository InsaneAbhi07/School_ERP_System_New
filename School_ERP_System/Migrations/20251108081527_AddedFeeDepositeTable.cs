using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_ErP.Migrations
{
    /// <inheritdoc />
    public partial class AddedFeeDepositeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_FeeDeposite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryCDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Session = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdmnNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cancel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeeHead = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Late = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Concession = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CashAmt = table.Column<int>(type: "int", nullable: false),
                    ChequeAmt = table.Column<int>(type: "int", nullable: false),
                    ChequeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChequeDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sid = table.Column<int>(type: "int", nullable: false),
                    NetFee = table.Column<int>(type: "int", nullable: false),
                    CBounce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CBounceDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_FeeDeposite", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_FeeDeposite");
        }
    }
}
