using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MultiLingo.Domain.Entities
{
    public class Turma
    {
        [Key]
        public Guid IdTurma { get; set; }

        public string Nome { get; set; }
        public bool IsDeletado { get; set; }
        public virtual List<AlunoTurma> Alunos { get; set; }

        public void Delete()
        {
            this.IsDeletado = true;
        }
    }
}
