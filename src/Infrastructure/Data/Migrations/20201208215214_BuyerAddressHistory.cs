using Microsoft.EntityFrameworkCore.Migrations;

namespace Microsoft.eShopWeb.Infrastructure.Data.Migrations
{
    public partial class BuyerAddressHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyerAddressHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreviousAddress_Street1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PreviousAddress_Street2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PreviousAddress_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PreviousAddress_State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PreviousAddress_ZipCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BuyerAddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerAddressHistories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyerAddressHistories");
        }
    }
}
