using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Persistence.nHibernate.Repositorio;
using UpperAcademy.Testes.Servicos;
using NUnit.Framework;

namespace UpperAcademy.Testes.Repositorios
{
    [TestFixture]
    public class BancoTeste
    {
        AlunoTeste alunoTeste;
        ProfessorTeste professorTeste;
        TurmaTeste turmaTeste;
        ServGeradorSequencialEntidadeTeste servGeradorSequencialEntidadeTeste;

        public BancoTeste() { }


        [Test]
        public void a_GerarBanco()
        {
            Assert.IsTrue(Banco.CriarBancoDeDados());
        }

        [Test]
        public void b_CargaInicialGeradorSequencialEntidade()
        {
            servGeradorSequencialEntidadeTeste = new ServGeradorSequencialEntidadeTeste();
            Assert.IsTrue(servGeradorSequencialEntidadeTeste.Carga_Inicial());
        }

        [Test]
        public void c_CargaInicialAluno()
        {
            alunoTeste = new AlunoTeste();
            Assert.IsTrue(alunoTeste.Carga_Inicial());
        }

        [Test]
        public void d_CargaInicialProfessor()
        {
            professorTeste = new ProfessorTeste();
            Assert.IsTrue(professorTeste.Carga_Inicial());
        }

        [Test]
        public void e_CargaInicialTurma()
        {
            turmaTeste = new TurmaTeste();
            Assert.IsTrue(turmaTeste.Carga_Inicial());
        }

    }
}
