using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class PropertyImageMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "property_images",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    property_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    file_name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    file_path = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    file_type = table.Column<string>(type: "varchar(5)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    file_size = table.Column<int>(type: "int", nullable: false),
                    uploaded_by_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_property_images", x => x.id);
                    table.ForeignKey(
                        name: "FK_property_images_properties_property_id",
                        column: x => x.property_id,
                        principalTable: "properties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_property_images_users_uploaded_by_id",
                        column: x => x.uploaded_by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "profiles",
                keyColumn: "id",
                keyValue: new Guid("a2bf83f7-1e91-438a-a204-56064519acb2"),
                column: "created_at",
                value: new DateTime(2023, 10, 21, 10, 17, 22, 489, DateTimeKind.Utc).AddTicks(9110));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a2bf83f7-1e91-438a-a204-56064519acb1"),
                column: "created_at",
                value: new DateTime(2023, 10, 21, 10, 17, 22, 486, DateTimeKind.Utc).AddTicks(440));

            migrationBuilder.CreateIndex(
                name: "IX_property_images_property_id",
                table: "property_images",
                column: "property_id");

            migrationBuilder.CreateIndex(
                name: "IX_property_images_uploaded_by_id",
                table: "property_images",
                column: "uploaded_by_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "property_images");

            migrationBuilder.UpdateData(
                table: "profiles",
                keyColumn: "id",
                keyValue: new Guid("a2bf83f7-1e91-438a-a204-56064519acb2"),
                column: "created_at",
                value: new DateTime(2023, 10, 20, 20, 18, 52, 747, DateTimeKind.Utc).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("a2bf83f7-1e91-438a-a204-56064519acb1"),
                column: "created_at",
                value: new DateTime(2023, 10, 20, 20, 18, 52, 743, DateTimeKind.Utc).AddTicks(3670));
        }
    }
}
