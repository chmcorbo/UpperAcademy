using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using UpperAcademy.Dominio.Servicos;

namespace UpperAcademy.Testes.Servicos
{
    [TestFixture]
    public class ServListaFixaNivelTeste
    {
        ServListaFixaNivel _niveis = new ServListaFixaNivel();

        public ServListaFixaNivelTeste()
        {
            _niveis = new ServListaFixaNivel();
        }

        [Test]
        public void TestarObterBasico()
        {
            String atual = _niveis.ObterPelaChave(1);
            String esperado = "Básico";

            Assert.AreEqual(esperado, atual);
        }

        [Test]
        public void TestarObterIntermediario()
        {
            String atual = _niveis.ObterPelaChave(2);
            String esperado = "Intermediário";

            Assert.AreEqual(esperado, atual);
        }

        [Test]
        public void TestarObterAvancado()
        {
            String atual = _niveis.ObterPelaChave(3);
            String esperado = "Avançado";

            Assert.AreEqual(esperado, atual);
        }

        [Test]
        public void TestarListaNiveis()
        {
            List<String> esperado = new List<String>();
            esperado.Add("Básico");
            esperado.Add("Intermediário");
            esperado.Add("Avançado");

            List<String> atual = _niveis.Listar();

            Assert.AreEqual(esperado, atual);
        }

        [Test]
        public void TestarObterChaveInvalida()
        {
            String atual = _niveis.ObterPelaChave(4);
            String esperado = "";

            Assert.AreEqual(esperado, atual);
        }



    }
}
