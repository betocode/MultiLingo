using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiLingo.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    IdAluno = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Matricula = table.Column<string>(nullable: false),
                    IdTurma = table.Column<Guid>(nullable: false),
                    IsDeletado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.IdAluno);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    IdTurma = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    IsDeletado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.IdTurma);
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
                        name: "FK_AlunoTurma_Alunos_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Alunos",
                        principalColumn: "IdAluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoTurma_Turmas_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turmas",
                        principalColumn: "IdTurma",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Turmas");
        }
    }
}
