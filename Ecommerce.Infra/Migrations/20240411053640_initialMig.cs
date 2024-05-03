using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Infra.Migrations
{
    /// <inheritdoc />
    public partial class initialMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandDb",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BrandName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandDb", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categories = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageDb",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Image = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageDb", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "ProductsDb",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SKU = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Is_New = table.Column<bool>(type: "INTEGER", nullable: false),
                    OfferEnds = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: false),
                    Sale_Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Full_Description = table.Column<string>(type: "TEXT", nullable: true),
                    Short_Description = table.Column<string>(type: "TEXT", nullable: true),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductCategory = table.Column<string>(type: "TEXT", nullable: true),
                    Tag = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsDb", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductsDb_BrandDb_BrandId",
                        column: x => x.BrandId,
                        principalTable: "BrandDb",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsDb_CategoriesDb_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoriesDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VariationDb",
                columns: table => new
                {
                    VariationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariationDb", x => x.VariationId);
                    table.ForeignKey(
                        name: "FK_VariationDb_ProductsDb_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductsDb",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Size_StocksDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VariationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size_StocksDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Size_StocksDb_VariationDb_VariationId",
                        column: x => x.VariationId,
                        principalTable: "VariationDb",
                        principalColumn: "VariationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsDb_BrandId",
                table: "ProductsDb",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsDb_CategoryId",
                table: "ProductsDb",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Size_StocksDb_VariationId",
                table: "Size_StocksDb",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_VariationDb_ProductId",
                table: "VariationDb",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageDb");

            migrationBuilder.DropTable(
                name: "Size_StocksDb");

            migrationBuilder.DropTable(
                name: "VariationDb");

            migrationBuilder.DropTable(
                name: "ProductsDb");

            migrationBuilder.DropTable(
                name: "BrandDb");

            migrationBuilder.DropTable(
                name: "CategoriesDb");
        }
    }
}
