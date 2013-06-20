using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Dominio.Enumerados;
using UpperAcademy.Persistence.nHibernate.Modelo;
using UpperAcademy.Persistence.nHibernate.Repositorio;
using UpperAcademy.Persistence.nHibernate.Servicos;
using UpperAcademy.Testes.Repositorios;

namespace UpperAcademy.Testes.Servicos
{
    [TestFixture]
    public class ServMatricularAlunoTeste
    {
        
        [Test]
        public void TestarMatricularAluno()
        {
            RepositorioEntidadeSequencial repositorioEntidadeSequencial = new RepositorioEntidadeSequencial();
            RepositorioGenerico<Aluno> repositorioAluno = new RepositorioGenerico<Aluno>();
            RepositorioGenerico<Turma> repositorioTurma= new RepositorioGenerico<Turma>();
            ServMatricularAluno servMatricularAluno = new ServMatricularAluno();

            Aluno _aluno = repositorioAluno.ListarTudo().FirstOrDefault(); // Deve ser alterada por uma consulta que só traga alunos não matriculados;
            if (_aluno == null)
            {
                AlunoTeste alunoTeste = new AlunoTeste();
                alunoTeste.Carga_Inicial();
                _aluno = repositorioAluno.ListarTudo().FirstOrDefault(); // Deve ser alterada por uma consulta que só traga alunos não matriculados;
            }
            
            Turma _turma = repositorioTurma.ListarTudo().FirstOrDefault();
            if (_turma == null)
            {
                TurmaTeste turmaTeste = new TurmaTeste();
                turmaTeste.Incluir_Turma_Sem_Aluno_Sem_Professor();
                _turma = repositorioTurma.ListarTudo().FirstOrDefault();
            }

            EntidadeSequencial entidadeSequencial = repositorioEntidadeSequencial.ObterPoNome(_aluno.GetType().Name);

            if (entidadeSequencial == null)
            {
                entidadeSequencial = new EntidadeSequencial() { Nome = _aluno.GetType().Name, UltimoCodigo = 1000 };
                repositorioEntidadeSequencial.Adicionar(entidadeSequencial);
            }

            Int32 qtdeAlunoAtual = _turma.Alunos.Count;

            servMatricularAluno.Executar(_turma, _aluno);

            Int32 qtdeAlunoEsperado = qtdeAlunoAtual + 1;
            Int32 statusAlunoEsperado = 2;
            qtdeAlunoAtual = _turma.Alunos.Count;


            Assert.AreEqual(statusAlunoEsperado, _aluno.Status);
            Assert.AreEqual(qtdeAlunoEsperado, qtdeAlunoAtual);
        }
    }
}
