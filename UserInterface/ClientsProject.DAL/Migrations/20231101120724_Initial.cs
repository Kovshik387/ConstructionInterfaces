using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClientsProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id_client = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    surname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    contact = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    email = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    rating = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("clients_pkey", x => x.id_client);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id_product = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    count = table.Column<int>(type: "integer", nullable: true),
                    daterelease = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("product_pkey", x => x.id_product);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    idorder = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    count = table.Column<int>(type: "integer", nullable: true),
                    daterelease = table.Column<DateOnly>(type: "date", nullable: true),
                    id_client = table.Column<int>(type: "integer", nullable: false),
                    id_product = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("orders_pkey", x => x.idorder);
                    table.ForeignKey(
                        name: "orders_id_client_fkey",
                        column: x => x.id_client,
                        principalTable: "clients",
                        principalColumn: "id_client");
                    table.ForeignKey(
                        name: "orders_id_product_fkey",
                        column: x => x.id_product,
                        principalTable: "product",
                        principalColumn: "id_product");
                });

            migrationBuilder.CreateTable(
                name: "review",
                columns: table => new
                {
                    id_review = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    message = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    ishelpful = table.Column<bool>(type: "boolean", nullable: true),
                    id_client = table.Column<int>(type: "integer", nullable: false),
                    id_product = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("review_pkey", x => x.id_review);
                    table.ForeignKey(
                        name: "review_id_client_fkey",
                        column: x => x.id_client,
                        principalTable: "clients",
                        principalColumn: "id_client");
                    table.ForeignKey(
                        name: "review_id_product_fkey",
                        column: x => x.id_product,
                        principalTable: "product",
                        principalColumn: "id_product");
                });

            migrationBuilder.CreateIndex(
                name: "clients_login_key",
                table: "clients",
                column: "login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_id_client",
                table: "orders",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_orders_id_product",
                table: "orders",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_review_id_client",
                table: "review",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_review_id_product",
                table: "review",
                column: "id_product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "review");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
