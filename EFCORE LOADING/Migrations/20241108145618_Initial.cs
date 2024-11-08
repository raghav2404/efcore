using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCORE_LOADING.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VillaAmeneties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaAmeneties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VillaAmeneties_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "ID", "Name", "Price" },
                values: new object[] { 1, "lAKE VIEW", 9999.0 });

            migrationBuilder.InsertData(
                table: "VillaAmeneties",
                columns: new[] { "Id", "Name", "VillaId" },
                values: new object[] { 2, "jACCUZZI", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_VillaAmeneties_VillaId",
                table: "VillaAmeneties",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaAmeneties");

            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
