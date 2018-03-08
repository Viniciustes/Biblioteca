using Biblioteca.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Data.Models
{
    public class HorarioFuncionamento
    {
        [Key]
        public Guid Id { get; set; }
        public Filial Filial { get; set; }

        public EnumDiaDaSemana DiaDaSemana { get; set; }

        [Range(0,23)]
        public int HoraDeAbertura { get; set; }

        [Range(0, 23)]
        public int HoraDeFechamento { get; set; }
    }
}