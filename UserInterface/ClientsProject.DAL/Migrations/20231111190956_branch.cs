using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientsProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class branch1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "product",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branch",
                table: "product");
        }
    }
}
