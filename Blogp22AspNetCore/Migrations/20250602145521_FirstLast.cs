using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Blogp22AspNetCore.Migrations
{
    /// <inheritdoc />
    public partial class FirstLast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CNTR_EM133",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdEkg = table.Column<int>(type: "integer", nullable: false),
                    BrigadaId = table.Column<int>(type: "integer", nullable: false),
                    kWh_im = table.Column<long>(type: "bigint", nullable: false),
                    kWh_ex = table.Column<long>(type: "bigint", nullable: false),
                    kWArh_im = table.Column<long>(type: "bigint", nullable: false),
                    TimestampOnServer = table.Column<long>(type: "bigint", nullable: false),
                    TimestampFromEkg = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CNTR_EM133", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CNTR_EM133");
        }
    }
}
