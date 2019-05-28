using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EstudoProva.Migrations
{
    public partial class relacionamentoNNCursoDisc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CursoDisciplina",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cursoID = table.Column<int>(nullable: false),
                    disciplinaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoDisciplina", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_Curso_cursoID",
                        column: x => x.cursoID,
                        principalTable: "Curso",
                        principalColumn: "identificador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_Disciplina_disciplinaID",
                        column: x => x.disciplinaID,
                        principalTable: "Disciplina",
                        principalColumn: "identificador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoDisciplina_cursoID",
                table: "CursoDisciplina",
                column: "cursoID");

            migrationBuilder.CreateIndex(
                name: "IX_CursoDisciplina_disciplinaID",
                table: "CursoDisciplina",
                column: "disciplinaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoDisciplina");
        }
    }
}
