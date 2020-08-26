using System;

namespace MultiLingo.Domain.Arguments.Aluno
{
    public class AddAlunoRequest
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public Guid IdTurma { get; set; }
    }
}
