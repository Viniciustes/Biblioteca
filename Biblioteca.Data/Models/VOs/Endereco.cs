using Biblioteca.Data.Models.Enums;
using System;

namespace Biblioteca.Data.Models.VOs
{
    public class Endereco
    {
        public Endereco() { }

        public Endereco(string logadouro, string numero, string complemento, string estado, string cidade, string cEP, EnumTipoEndereco tipo)
        {
            Id = Guid.NewGuid();
            Logadouro = logadouro;
            Numero = numero;
            Complemento = complemento;
            Estado = estado;
            Cidade = cidade;
            CEP = cEP;
            Tipo = tipo;
        }

        public Guid Id { get; private set; }
        public string Logadouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
        public string CEP { get; private set; }
        public EnumTipoEndereco Tipo { get; private set; }
    }
}