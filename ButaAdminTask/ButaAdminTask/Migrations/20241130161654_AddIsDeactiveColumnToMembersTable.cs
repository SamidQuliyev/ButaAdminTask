using Microsoft.EntityFrameworkCore.Migrations;

namespace ButaAdminTask.Migrations
{
    public partial class AddIsDeactiveColumnToMembersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsDeactive",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeactive",
                table: "Members");
        }
    }
}
