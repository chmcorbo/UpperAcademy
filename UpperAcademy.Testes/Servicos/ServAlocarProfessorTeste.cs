using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Persistence.nHibernate.Repositorio;
using UpperAcademy.Persistence.nHibernate.Servicos;
using UpperAcademy.Testes.Repositorios;

namespace UpperAcademy.Testes.Servicos
{
    [TestFixture]
    public class ServAlocarProfessorTeste
    {
        RepositorioGenerico<Professor> _repositorioProfessor;
        RepositorioGenerico<Turma> _repositorioTurma;
        ServAlocarProfessor _servAlocarProfessor;
        
        public ServAlocarProfessorTeste()
        {
            _repositorioProfessor = new RepositorioGenerico<Professor>();
            _repositorioTurma = new RepositorioGenerico<Turma>();
            _servAlocarProfessor = new ServAlocarProfessor();
        }

        [Test]
        public void TestarAlocacaoProfessorEmTurma()
        {
            Professor _professor = _repositorioProfessor.ListarTudo().FirstOrDefault();

            if (_professor == null)
            {
                ProfessorTeste professorTeste = new ProfessorTeste();
                professorTeste.Carga_Inicial();
                _professor = _repositorioProfessor.ListarTudo().FirstOrDefault();
            }

            Turma _turma = _repositorioTurma.ListarTudo().FirstOrDefault();

            if (_turma == null)
            {
                TurmaTeste turmaTeste = new TurmaTeste();
                turmaTeste.Incluir_Turma_Sem_Aluno_Sem_Professor();
                _turma = _repositorioTurma.ListarTudo().FirstOrDefault();
            }

            Int16 statusProfessorEsperado = 2;
            

            _servAlocarProfessor.Executar(_turma, _professor);

            Assert.AreEqual(statusProfessorEsperado, _professor.Status);

            Assert.AreSame(_professor, _turma.Professor);
        }

    }
}
