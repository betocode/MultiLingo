using System;

namespace MultiLingo.Domain.Arguments.Turma
{
    public class EditTurmaRequest
    {
        public string Nome { get; set; }

        public Guid IdTurma { get; set; }
    }
}
