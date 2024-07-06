using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class MembershipTypeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MemberShipType",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql("Update MemberShipType SET name = 'Pay as You go' WHERE Id = 1");
            migrationBuilder.Sql("Update MemberShipType SET name = 'Monthly' WHERE Id = 2");
            migrationBuilder.Sql("Update MemberShipType SET name = 'Quaterly' WHERE Id = 3");
            migrationBuilder.Sql("Update MemberShipType SET name = 'Yearly' WHERE Id = 4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "MemberShipType");
        }
    }
}
