using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MultiLingo.Domain.Entities
{
    public class Aluno
    {
        [Key]
        public Guid IdAluno { get; set; }
        [Required]
        [MaxLength(200,ErrorMessage =  "Nome não pode ser maior que 200 caracteres")]
        public string Nome { get; set; }
        [Required]
        public string Matricula { get; set; }
        [Required]
        public Guid IdTurma { get; set; }

        public bool IsDeletado { get; set; }

        public virtual List<AlunoTurma> Turmas {get;set;}
    }
}
