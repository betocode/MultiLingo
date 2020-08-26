using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MultiLingo.Domain.Entities
{
    public class Aluno
    {
        public Aluno(string nome,string matricula)
        {
            this.IdAluno = Guid.NewGuid();
            this.Nome = nome;
            this.Matricula = matricula;
        }
        [Key]
        public Guid IdAluno { get; set; }
        [Required]
        [MaxLength(200,ErrorMessage =  "Nome não pode ser maior que 200 caracteres")]
        public string Nome { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Matricula não pode ser maior que 200 caracteres")]
        public string Matricula { get; set; }
        
        public bool IsDeletado { get; set; }

        public virtual List<AlunoTurma> Turmas {get;set;}


        public void ChangeAluno (string nome,string matricula)
        {
            this.Nome = nome;
            this.Matricula = matricula;
        }

        public void Delete()
        {
            this.IsDeletado = true;
        }

    }
}
