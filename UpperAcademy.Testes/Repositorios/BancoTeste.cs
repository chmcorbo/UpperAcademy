using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Persistence.nHibernate.Repositorio;
using NUnit.Framework;

namespace UpperAcademy.Testes.Repositorios
{
    [TestFixture]
    public class BancoTeste
    {
        public BancoTeste()
        {
        }

        [Test]
        public void GerarBanco()
        {
            Assert.IsTrue(Banco.gerarBanco());
        }

    }
}
