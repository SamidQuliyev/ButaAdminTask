using Microsoft.EntityFrameworkCore.Migrations;

namespace ButaAdminTask.Migrations
{
    public partial class CreateMembersTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Members");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
