using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Persistence.nHibernate.Repositorio;

namespace UpperAcademy.Testes.Repositorios
{
    [TestFixture]
    public class MidiaTeste
    {
        RepositorioGenerico<Midia> repositorio;
        Midia midia;
        Midia midiaRecuperada;

        public MidiaTeste()
        {
            repositorio = new RepositorioGenerico<Midia>();
        }


        public void Incluir_Midias()
        {
            midia = new Midia();
            midia.Descricao = "Desenvolvimento em camadas com c#";
            midia.Autor = "Carlos Olavo de Azevedo";
            midia.Qtde_Copias = 3;
            midia.Qtde_Disponivel = midia.Qtde_Copias;
            repositorio.Atualizar(midia);

            midia = new Midia();
            midia.Descricao = "Padrões de projeto";
            midia.Autor = "Gang of four";
            midia.Qtde_Copias = 2;
            midia.Qtde_Disponivel = midia.Qtde_Copias;
            repositorio.Atualizar(midia);
        }

        [Test]
        public void a_Incluir_Midia()
        {
            Incluir_Midias();
            midia = new Midia();
            midia.Descricao = "DDD - Atacando complexidade de código do software";
            midia.Autor = "Eric Evans";
            midia.Qtde_Copias = 5;
            midia.Qtde_Disponivel = midia.Qtde_Copias;
            repositorio.Atualizar(midia);

            midiaRecuperada = repositorio.ObterPorID(midia.ID);
            Assert.AreSame(midia, midiaRecuperada);
        }

        [Test]
        public void b_Alterar_Midia()
        {
            Incluir_Midias();
            midia = repositorio.ListarTudo().FirstOrDefault();
            midia.Descricao = "Domain Driven Design";
            repositorio.Atualizar(midia);

            midiaRecuperada = repositorio.ObterPorID(midia.ID);

            Assert.AreEqual(midia.Descricao, midiaRecuperada.Descricao);
        }

        [Test]
        public void c_Excluir_Midia()
        {
            Incluir_Midias();
            midiaRecuperada = null;
            midia = repositorio.ListarTudo().FirstOrDefault();
            String id_midia = midia.ID;
            repositorio.Excluir(midia);

            midiaRecuperada = repositorio.ObterPorID(id_midia);

            Assert.IsNull(midiaRecuperada);
        }

    }
}

