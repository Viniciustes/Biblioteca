using Biblioteca.Data.Models;
using Biblioteca.Data.Models.Enums;
using Biblioteca.Data.Models.VOs;
using System;

namespace Biblioteca.Data.Context
{
    public class DbInicializacao
    {
        public static Acervo InicializarAcervoLivro()
        {

            var endereco = new Endereco("Logadouro Endereço", "Numero Endereço", "Complemento Endereço", "Estado Endereço", "Cidade Endereço", "CEP Endereço", EnumTipoEndereco.Padrao);

            var filial = new Filial("Nome Filial", endereco, "Telefone Filial", "Descrição Filial", DateTime.Now, "ImagemUrl Filial");

            var status = new Status("Nome Status", "Descrição Status");

            var livro = new Livro("Titulo Livro", DateTime.Now.Year, status, 9.99m, "Imagem Acervo", 10, filial, "ISBN Livro", "Autor Livro", "Codigo de Barras Livro");

            return livro;
        }

        public static Acervo InicializarAcervoVideo()
        {
            var endereco = new Endereco("Logadouro Endereço", "Numero Endereço", "Complemento Endereço", "Estado Endereço", "Cidade Endereço", "CEP Endereço", EnumTipoEndereco.Padrao);

            var filial = new Filial("Nome Filial", endereco, "Telefone Filial", "Descrição Filial", DateTime.Now, "ImagemUrl Filial");

            var status = new Status("Nome Status", "Descrição Status");

            var video = new Video("Titulo Video", DateTime.Now.Year, status, 19.99m, "Imagem Acervo", 7, filial,"Diretor do Video");

            return video;
        }
    }
}
