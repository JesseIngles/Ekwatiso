using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbCategorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCategorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbGerentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    NomeCompleto = table.Column<string>(type: "TEXT", nullable: false),
                    Admin = table.Column<bool>(type: "INTEGER", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbGerentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbPaises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPaises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbProvincias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    PaisId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProvincias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbProvincias_TbPaises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "TbPaises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumeroIdentificacao = table.Column<string>(type: "TEXT", nullable: false),
                    NomeCompleto = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    ProvinciaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbUsers_TbProvincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "TbProvincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbCampanhas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Fotografias = table.Column<string>(type: "TEXT", nullable: false),
                    meta = table.Column<decimal>(type: "TEXT", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AutorId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProvinciaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TbGerenteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCampanhas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbCampanhas_TbCategorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "TbCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbCampanhas_TbGerentes_TbGerenteId",
                        column: x => x.TbGerenteId,
                        principalTable: "TbGerentes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbCampanhas_TbProvincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "TbProvincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbCampanhas_TbUsers_AutorId",
                        column: x => x.AutorId,
                        principalTable: "TbUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbDoacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DoadorId = table.Column<int>(type: "INTEGER", nullable: false),
                    CampanhaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantia = table.Column<decimal>(type: "TEXT", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Confirmado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbDoacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbDoacoes_TbCampanhas_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "TbCampanhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbDoacoes_TbUsers_DoadorId",
                        column: x => x.DoadorId,
                        principalTable: "TbUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbCampanhas_AutorId",
                table: "TbCampanhas",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TbCampanhas_CategoriaId",
                table: "TbCampanhas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TbCampanhas_ProvinciaId",
                table: "TbCampanhas",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_TbCampanhas_TbGerenteId",
                table: "TbCampanhas",
                column: "TbGerenteId");

            migrationBuilder.CreateIndex(
                name: "IX_TbDoacoes_CampanhaId",
                table: "TbDoacoes",
                column: "CampanhaId");

            migrationBuilder.CreateIndex(
                name: "IX_TbDoacoes_DoadorId",
                table: "TbDoacoes",
                column: "DoadorId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProvincias_PaisId",
                table: "TbProvincias",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_TbUsers_ProvinciaId",
                table: "TbUsers",
                column: "ProvinciaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbDoacoes");

            migrationBuilder.DropTable(
                name: "TbCampanhas");

            migrationBuilder.DropTable(
                name: "TbCategorias");

            migrationBuilder.DropTable(
                name: "TbGerentes");

            migrationBuilder.DropTable(
                name: "TbUsers");

            migrationBuilder.DropTable(
                name: "TbProvincias");

            migrationBuilder.DropTable(
                name: "TbPaises");
        }
    }
}
