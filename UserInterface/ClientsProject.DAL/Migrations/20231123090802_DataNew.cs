using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClientsProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DataNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Branch",
                table: "product",
                type: "text",
                nullable: false,
                defaultValueSql: "''::text",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateOnly>(
                name: "lastview",
                table: "product",
                type: "date",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "clients",
                type: "text",
                nullable: false,
                defaultValueSql: "''::text",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateOnly>(
                name: "lastvisit",
                table: "clients",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "registrationdate",
                table: "clients",
                type: "date",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "viewclient",
                columns: table => new
                {
                    id_view = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_client = table.Column<int>(type: "integer", nullable: false),
                    id_product = table.Column<int>(type: "integer", nullable: false),
                    dateview = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("viewclient_pkey", x => x.id_view);
                    table.ForeignKey(
                        name: "viewclient_id_client_fkey",
                        column: x => x.id_client,
                        principalTable: "clients",
                        principalColumn: "id_client");
                    table.ForeignKey(
                        name: "viewclient_id_product_fkey",
                        column: x => x.id_product,
                        principalTable: "product",
                        principalColumn: "id_product");
                });

            migrationBuilder.CreateIndex(
                name: "IX_viewclient_id_client",
                table: "viewclient",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_viewclient_id_product",
                table: "viewclient",
                column: "id_product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "viewclient");

            migrationBuilder.DropColumn(
                name: "lastview",
                table: "product");

            migrationBuilder.DropColumn(
                name: "lastvisit",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "registrationdate",
                table: "clients");

            migrationBuilder.AlterColumn<string>(
                name: "Branch",
                table: "product",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValueSql: "''::text");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "clients",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValueSql: "''::text");
        }
    }
}
