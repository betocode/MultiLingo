using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MultiLingo.Domain.Entities
{
    public class Turma
    {
        public Turma(string nome)
        {
            this.IdTurma = Guid.NewGuid();
            this.Nome = nome;
            this.IsDeletado = false;
        }
        [Key]
        public Guid IdTurma { get; private set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Nome não pode ser maior que 200 caracteres")]
        public string Nome { get; private set; }
        public bool IsDeletado { get; private set; }
        public virtual List<AlunoTurma> Alunos { get; private set; }

        public void Delete()
        {
            this.IsDeletado = true;
        }
        public void ChangeName(string nome)
        {
            this.Nome = nome;
        }
    }
}
