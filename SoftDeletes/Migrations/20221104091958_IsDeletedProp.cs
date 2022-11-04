using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftDeletes.Migrations
{
    public partial class IsDeletedProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Publisher",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Book",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Book");
        }
    }
}
