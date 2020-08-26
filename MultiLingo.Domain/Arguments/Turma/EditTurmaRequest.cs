using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MultiLingo.Domain.Arguments.Turma
{
    public class EditTurmaRequest
    {
        public string Nome { get; set; }

        public Guid IdTurma { get; set; }
    }
}
