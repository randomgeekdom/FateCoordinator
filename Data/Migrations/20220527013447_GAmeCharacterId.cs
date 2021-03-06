using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FateCoordinator.Data.Migrations
{
    public partial class GAmeCharacterId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CharacterId",
                table: "GameCharacters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "GameCharacters");
        }
    }
}
