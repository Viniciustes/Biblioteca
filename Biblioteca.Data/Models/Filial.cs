using Biblioteca.Data.Models.VOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Data.Models
{
    public class Filial
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage ="Utilizar no máximo 30 caracteres")]
        public string Nome { get; set; }

        [Required]
        public Endereco Endereco { get; set; }

        [Required]
        public string Telefone { get; set; }

        public string Descricao { get; set; }

        public DateTime DtAbertura { get; set; }

        public virtual IEnumerable<Cliente> Clientes { get; set; }
        public virtual IEnumerable<Acervo> Patrimonios { get; set; }

        public string ImagemUrl { get; set; }
    }
}
