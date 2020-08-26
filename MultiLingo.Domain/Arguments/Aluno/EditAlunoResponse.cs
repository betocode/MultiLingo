using System;

namespace MultiLingo.Domain.Arguments.Aluno
{
    public class EditAlunoResponse
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public Guid IdAluno { get; set; }
        public static explicit operator EditAlunoResponse(Entities.Aluno aluno)
        {
            return new EditAlunoResponse { IdAluno = aluno.IdAluno, Nome = aluno.Nome, Matricula = aluno.Matricula };
        }
    }
}
