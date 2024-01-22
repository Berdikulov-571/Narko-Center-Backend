using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NarkoCenter.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ColumnAddedTableHelp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WhereToPickUp",
                table: "Helps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhereToPickUp",
                table: "Helps");
        }
    }
}
