using Biblioteca.Data.Models.VOs;
using System;
using System.Collections.Generic;

namespace Biblioteca.Data.Models
{
    public class Filial : Base
    {
        public Filial() { }

        public Filial(string nome, Endereco endereco, string telefone, string descricao, DateTime dtAbertura, string imagemUrl)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Descricao = descricao;
            DtAbertura = dtAbertura;
            ImagemUrl = imagemUrl;
        }

        public string Nome { get; private set; }
        public Endereco Endereco { get; private set; }
        public string Telefone { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DtAbertura { get; private set; }
        public string ImagemUrl { get; private set; }

        public virtual IEnumerable<Cliente> Clientes { get; set; }
        public virtual IEnumerable<Acervo> Patrimonios { get; set; }
    }
}
