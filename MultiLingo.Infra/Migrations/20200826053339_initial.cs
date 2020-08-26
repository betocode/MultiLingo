using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiLingo.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    IdAluno = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Matricula = table.Column<string>(maxLength: 200, nullable: false),
                    IsDeletado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.IdAluno);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    IdTurma = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    IsDeletado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.IdTurma);
                });

            migrationBuilder.CreateTable(
                name: "AlunoTurma",
                columns: table => new
                {
                    IdAluno = table.Column<Guid>(nullable: false),
                    IdTurma = table.Column<Guid>(nullable: false),
                    IdAlunoTurma = table.Column<Guid>(nullable: false),
                    DataInsercao = table.Column<DateTime>(nullable: false),
                    DataRemovido = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoTurma", x => new { x.IdAluno, x.IdTurma });
                    table.UniqueConstraint("AK_AlunoTurma_IdAlunoTurma", x => x.IdAlunoTurma);
                    table.ForeignKey(
                        name: "FK_AlunoTurma_Aluno_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Aluno",
                        principalColumn: "IdAluno",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlunoTurma_Turma_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turma",
                        principalColumn: "IdTurma",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTurma_IdTurma",
                table: "AlunoTurma",
                column: "IdTurma");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoTurma");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Turma");
        }
    }
}
