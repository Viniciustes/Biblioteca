using Biblioteca.Data.Models.VOs;
using System;
using System.Collections.Generic;

namespace Biblioteca.Data.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public List<Endereco> Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string TelefoneCelular { get; set; }
        public string CPF { get; set; }
        
        public virtual Cartao Cartao { get; set; }
        public virtual Filial FilialResponsavel { get; set; }
    }
}