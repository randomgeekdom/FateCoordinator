using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FateCoordinator.Data.Migrations
{
    public partial class AllowCharactersToBePubliclyAvailable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Characters",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Characters");
        }
    }
}
