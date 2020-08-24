using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MultiLingo.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

    }
}
