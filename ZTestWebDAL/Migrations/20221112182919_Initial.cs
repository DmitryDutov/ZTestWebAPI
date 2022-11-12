using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZTestWebDAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ValuesListSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValuesListSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValuesSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValuesListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValuesSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValuesSet_ValuesListSet_ValuesListId",
                        column: x => x.ValuesListId,
                        principalTable: "ValuesListSet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValuesListSet_Id",
                table: "ValuesListSet",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ValuesSet_Id",
                table: "ValuesSet",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ValuesSet_ValuesListId",
                table: "ValuesSet",
                column: "ValuesListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValuesSet");

            migrationBuilder.DropTable(
                name: "ValuesListSet");
        }
    }
}
