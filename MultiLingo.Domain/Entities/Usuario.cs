using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MultiLingo.Domain.Entities
{
    public class Usuario
    {
        public Usuario(string login, string senha)
        {
            this.IdUsuario = Guid.NewGuid();
            this.Login = login;
            this.Senha = senha;
        }
        [Key]
        public Guid IdUsuario { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Login não pode ser maior que 200 caracteres")]
        public string Login { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Senha não pode ser maior que 200 caracteres")]
        public string Senha { get; set; }

    }
}
