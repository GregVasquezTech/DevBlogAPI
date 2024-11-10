using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevBlog.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedColumnsForGuidActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Categories",
                newName: "Active");

            migrationBuilder.AlterColumn<Guid>(
                name: "GuidId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Categories",
                newName: "IsDeleted");

            migrationBuilder.AlterColumn<Guid>(
                name: "GuidId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
