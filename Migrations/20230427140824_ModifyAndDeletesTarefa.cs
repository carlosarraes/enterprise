using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace enterprise.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDeletesAndTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "ALTER TABLE \"Tarefas\" ALTER COLUMN \"Status\" TYPE boolean USING \"Status\"::boolean"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "ALTER TABLE \"Tarefas\" ALTER COLUMN \"Status\" TYPE text USING \"Status\"::text"
            );
        }
    }
}
