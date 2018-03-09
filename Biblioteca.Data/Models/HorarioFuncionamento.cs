using Biblioteca.Data.Models.Enums;
using System;

namespace Biblioteca.Data.Models
{
    public class HorarioFuncionamento : Base
    {
        public HorarioFuncionamento() { }

        public HorarioFuncionamento(Filial filial, EnumDiaDaSemana diaDaSemana, int horaDeAbertura, int horaDeFechamento)
        {
            Filial = filial;
            DiaDaSemana = diaDaSemana;
            HoraDeAbertura = horaDeAbertura;
            HoraDeFechamento = horaDeFechamento;
        }

        public Filial Filial { get; private set; }
        public EnumDiaDaSemana DiaDaSemana { get; private set; }
        public int HoraDeAbertura { get; private set; }
        public int HoraDeFechamento { get; private set; }
    }
}