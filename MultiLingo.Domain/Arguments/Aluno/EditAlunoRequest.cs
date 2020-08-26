using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLingo.Domain.Arguments.Aluno
{
    public class EditAlunoRequest
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public Guid IdAluno { get; set; }
    }
}
