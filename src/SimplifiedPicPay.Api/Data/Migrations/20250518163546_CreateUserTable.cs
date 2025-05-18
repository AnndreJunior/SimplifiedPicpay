using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SimplifiedPicPay.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar", maxLength: 254, nullable: false),
                    password = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    cpf_cnpj = table.Column<string>(type: "varchar", maxLength: 18, nullable: false),
                    wallet_balance = table.Column<decimal>(type: "numeric", nullable: false),
                    type = table.Column<string>(type: "varchar", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_email_cpf_cnpj",
                table: "users",
                columns: new[] { "email", "cpf_cnpj" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
