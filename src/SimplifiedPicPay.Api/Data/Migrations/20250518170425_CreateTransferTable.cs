using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SimplifiedPicPay.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTransferTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transfers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    payer_id = table.Column<long>(type: "bigint", nullable: false),
                    payee_id = table.Column<long>(type: "bigint", nullable: false),
                    value = table.Column<decimal>(type: "numeric", nullable: false),
                    transfer_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transfers", x => x.id);
                    table.ForeignKey(
                        name: "FK_transfers_users_payee_id",
                        column: x => x.payee_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transfers_users_payer_id",
                        column: x => x.payer_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transfers_payee_id",
                table: "transfers",
                column: "payee_id");

            migrationBuilder.CreateIndex(
                name: "IX_transfers_payer_id",
                table: "transfers",
                column: "payer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transfers");
        }
    }
}
