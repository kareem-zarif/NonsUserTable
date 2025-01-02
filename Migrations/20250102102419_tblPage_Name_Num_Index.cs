using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NonsUserTable.Migrations
{
    /// <inheritdoc />
    public partial class tblPage_Name_Num_Index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pages_Name_PageNumber",
                table: "Pages",
                columns: new[] { "Name", "PageNumber" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pages_Name_PageNumber",
                table: "Pages");
        }
    }
}
