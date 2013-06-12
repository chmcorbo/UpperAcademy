using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Persistence.nHibernate.Repositorio;
using UpperAcademy.Dominio.Servicos;
using UpperAcademy.Persistence.nHibernate.Servicos;
using NUnit.Framework;

namespace UpperAcademy.Testes.Repositorios
{
    public class EmprestimoMidiaTeste
    {
        private Midia midia;
        private AlunoTeste alunoTeste;
        private MidiaTeste midiaTeste;

        private RepositorioEmprestimoMidia repositorioEmprestimoMidia;
        private RepositorioGenerico<Aluno> repositorioAluno;
        private RepositorioGenerico<Midia> repositorioMidia;

        private IServEmprestarMidia servEmprestarMidia;

        public EmprestimoMidiaTeste()
        {
            alunoTeste = new AlunoTeste();
            midiaTeste = new MidiaTeste();

            repositorioEmprestimoMidia = new RepositorioEmprestimoMidia();
            repositorioAluno = new RepositorioGenerico<Aluno>();
            repositorioMidia = new RepositorioGenerico<Midia>();

            
        }

        [Test]
        public void Emprestar_Midia()
        {
            midiaTeste.Incluir_Midias();
            alunoTeste.Incluir_Alunos();
            midia = repositorioMidia.ListarTudo().FirstOrDefault();
            Int32 Qtde_Disponivel = midia.Qtde_Disponivel;

            servEmprestarMidia = new ServEmprestarMidia().Executar(midia,
                repositorioAluno.ListarTudo().FirstOrDefault(),
                DateTime.Now.AddDays(-10));

            Midia midiaRecuperada = repositorioMidia.ObterPorID(midia.ID);

            Assert.AreEqual(Qtde_Disponivel - 1, midiaRecuperada.Qtde_Disponivel);
        }
    



    }
}
