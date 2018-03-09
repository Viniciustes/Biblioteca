using Biblioteca.Data.Models.VOs;
using System;
using System.Collections.Generic;

namespace Biblioteca.Data.Models
{
    public class Cliente : Base
    {
        public Cliente() { }

        public Cliente(string nome, string sobrenome, List<Endereco> endereco, DateTime dataNascimento, string telefone, string telefoneCelular, string cPF, Cartao cartao, Filial filialResponsavel)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Endereco = endereco;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            TelefoneCelular = telefoneCelular;
            CPF = cPF;
            Cartao = cartao;
            FilialResponsavel = filialResponsavel;
        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public List<Endereco> Endereco { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Telefone { get; private set; }
        public string TelefoneCelular { get; private set; }
        public string CPF { get; private set; }
        public virtual Cartao Cartao { get; private set; }
        public virtual Filial FilialResponsavel { get; private set; }
    }
}