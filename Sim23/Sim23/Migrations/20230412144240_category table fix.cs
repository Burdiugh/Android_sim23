using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sim23.Migrations
{
    /// <inheritdoc />
    public partial class categorytablefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Priotity",
                table: "tblCategories",
                newName: "Priority");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "tblCategories",
                newName: "Priotity");
        }
    }
}
