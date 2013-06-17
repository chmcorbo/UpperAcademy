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
        AlunoTeste alunoTeste;
        ProfessorTeste professorTeste;

        public BancoTeste()
        {
        }

        [Test]
        public void GerarBanco()
        {
            Assert.IsTrue(Banco.CriarBancoDeDados());
        }

        [Test]
        public void CargaDadosInicial()
        {
            alunoTeste = new AlunoTeste();
            professorTeste = new ProfessorTeste();

            Assert.IsTrue(alunoTeste.Carga_Inicial());
            Assert.IsTrue(professorTeste.Carga_Inicial());
        }


    }
}
