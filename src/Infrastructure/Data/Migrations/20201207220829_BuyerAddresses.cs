using Microsoft.EntityFrameworkCore.Migrations;

namespace Microsoft.eShopWeb.Infrastructure.Data.Migrations
{
    public partial class BuyerAddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressVerified",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "Address_Street1",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "Address_Street2",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "Address_ZipCode",
                table: "Buyers");

            migrationBuilder.CreateTable(
                name: "BuyerAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    Address_Street1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address_Street2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address_State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressVerified = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyerAddress_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyerAddress_BuyerId",
                table: "BuyerAddress",
                column: "BuyerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyerAddress");

            migrationBuilder.AddColumn<string>(
                name: "AddressVerified",
                table: "Buyers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Buyers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Buyers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street1",
                table: "Buyers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street2",
                table: "Buyers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_ZipCode",
                table: "Buyers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
