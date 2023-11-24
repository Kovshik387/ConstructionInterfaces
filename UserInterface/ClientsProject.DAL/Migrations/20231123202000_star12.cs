using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientsProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class star12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Branch",
                table: "product",
                type: "text",
                nullable: true,
                defaultValueSql: "''::text",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValueSql: "''::text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Branch",
                table: "product",
                type: "text",
                nullable: false,
                defaultValueSql: "''::text",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValueSql: "''::text");
        }
    }
}
