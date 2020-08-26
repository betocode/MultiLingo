using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MultiLingo.Domain.Entities
{
    public class AlunoTurma
    {
        public AlunoTurma()
        {

        }
        public AlunoTurma(Guid idaluno, Guid idturma)
        {
            this.IdAluno = idaluno;
            this.IdTurma = idturma;
            this.IdAlunoTurma = Guid.NewGuid();
            this.DataInsercao = DateTime.Now;
            this.Ativo = true;
        }
        [Key]
        public Guid IdAlunoTurma { get; set; }
        [Required]
        public Guid IdAluno { get; set; }

        public Aluno Aluno { get; set; }
        [Required]
        public Guid IdTurma { get; set; }

        public Turma Turma { get; set; }

        [Required]
        public DateTime DataInsercao { get; set; }

        public DateTime? DataRemovido { get; set; }
        public bool Ativo { get; set; }

        public void Delete()
        {
            this.Ativo = false;
            this.DataRemovido = DateTime.Now;
        }
    }
}
