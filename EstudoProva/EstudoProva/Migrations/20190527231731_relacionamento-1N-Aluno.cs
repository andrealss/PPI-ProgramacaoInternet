using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EstudoProva.Migrations
{
    public partial class relacionamento1NAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cursoID",
                table: "Aluno",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_cursoID",
                table: "Aluno",
                column: "cursoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Curso_cursoID",
                table: "Aluno",
                column: "cursoID",
                principalTable: "Curso",
                principalColumn: "identificador",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Curso_cursoID",
                table: "Aluno");

            migrationBuilder.DropIndex(
                name: "IX_Aluno_cursoID",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "cursoID",
                table: "Aluno");
        }
    }
}
