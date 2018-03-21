using Biblioteca.Data.Models;
using Biblioteca.Data.Models.Enums;
using Biblioteca.Data.Models.VOs;
using System;
using System.Collections.Generic;

namespace Biblioteca.Data.Context
{
    public class DbInicializacao
    {
        public static Acervo InicializarAcervoLivro(Status status)
        {
            var endereco = new Endereco("Logadouro Endereço", "Numero Endereço", "Complemento Endereço", "Estado Endereço", "Cidade Endereço", "CEP Endereço", EnumTipoEndereco.Padrao);

            var filial = new Filial("Nome Filial", endereco, "Telefone Filial", "Descrição Filial", DateTime.Now, "ImagemUrl Filial");

            var livro = new Livro("Titulo Livro", DateTime.Now.Year, status, 9.99m, "Imagem Acervo", 10, filial, "ISBN Livro", "Autor Livro", "Codigo de Barras Livro");

            return livro;
        }

        public static Acervo InicializarAcervoVideo()
        {
            var endereco = new Endereco("Logadouro Endereço", "Numero Endereço", "Complemento Endereço", "Estado Endereço", "Cidade Endereço", "CEP Endereço", EnumTipoEndereco.Padrao);

            var filial = new Filial("Nome Filial", endereco, "Telefone Filial", "Descrição Filial", DateTime.Now, "ImagemUrl Filial");

            var status = new Status("Nome Status", "Descrição Status");

            var video = new Video("Titulo Video", DateTime.Now.Year, status, 19.99m, "Imagem Acervo", 7, filial, "Diretor do Video");

            return video;
        }

        public static Filial InicializarFilial()
        {
            var endereco = new Endereco("Logadouro Endereço", "Numero Endereço", "Complemento Endereço", "Estado Endereço", "Cidade Endereço", "CEP Endereço", EnumTipoEndereco.Padrao);

            var filial = new Filial("Nome Filial", endereco, "Telefone Filial", "Descrição Filial", DateTime.Now, "ImagemUrl Filial");

            return filial;
        }

        public static List<Status> InicializarStatus()
        {
            return new List<Status>
            {
                new Status("Checked Out", "Item emprestado"),
                new Status("Lost", "Item Perdido"),
                new Status("Available", "Item Disponível"),
                new Status("On Hold", "Item Reservado")
            };
        }

        public static Cliente InicializarCliente()
        {
            var endereco = new Endereco("Logadouro Endereço", "Numero Endereço", "Complemento Endereço", "Estado Endereço", "Cidade Endereço", "CEP Endereço", EnumTipoEndereco.Padrao);

            var enderecoFilial = new Endereco("Logadouro Endereço", "Numero Endereço", "Complemento Endereço", "Estado Endereço", "Cidade Endereço", "CEP Endereço", EnumTipoEndereco.Padrao);

            var filialResponsavel = new Filial("Nome Filial", enderecoFilial, "Telefone Filial", "Descrição Filial", DateTime.Now, "ImagemUrl Filial");

            var cartao = new Cartao(1.55m, DateTime.Now, null);

            return new Cliente("Nome do Cliente", "Sobre Nome do Cliente", new List<Endereco>() { endereco }, DateTime.Now.AddYears(-5), "3333-3333", "99999-9999", "99999999999", cartao, filialResponsavel);
        }
    }
}
