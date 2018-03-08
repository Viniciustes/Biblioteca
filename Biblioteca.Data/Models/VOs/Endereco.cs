using Biblioteca.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Data.Models.VOs
{
    public class Endereco
    {
        [Key]
        public Guid IdEndereco { get; set; }
        public string Logadouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public EnumTipoEndereco Tipo { get; set; }
    }
}