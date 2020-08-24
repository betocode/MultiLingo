using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MultiLingo.Domain.Entities
{
    public class AlunoTurma
    {
        [Key]
        public Guid IdAlunoTurma { get; set; }

        public Guid IdAluno { get; set; }

        public Aluno Aluno { get; set; }
        public Guid IdTurma { get; set; }

        public Turma Turma { get; set; }

        public DateTime DataInsercao { get; set; }

        public DateTime? DataRemovido { get; set; }
        public bool Ativo { get; set; }
    }
}
