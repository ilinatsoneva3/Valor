using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IT.Valor.Infrastructure.Migrations
{
    public partial class ChangeToBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Quotes",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "AddedOn",
                table: "Quotes",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Books",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "AddedOn",
                table: "Books",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "AddedOn",
                table: "Author",
                newName: "DateModified");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Author");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Quotes",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Quotes",
                newName: "AddedOn");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Books",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Books",
                newName: "AddedOn");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Author",
                newName: "AddedOn");
        }
    }
}
