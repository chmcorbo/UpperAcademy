using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Persistence.nHibernate.Modelo;
using UpperAcademy.Persistence.nHibernate.Servicos;
using UpperAcademy.Persistence.nHibernate.Repositorio;

namespace UpperAcademy.Testes.Servicos
{
    [TestFixture]
    public class ServGeradorSequencialEntidadeTeste
    {
        Aluno _aluno;
        EntidadeSequencial _entidadeSequencial; 
        RepositorioEntidadeSequencial _repositorioEntidadeCodigo;
        ServGerarCodigoEntidade _ServGerarCodigoEntidade;
        
        
        public ServGeradorSequencialEntidadeTeste()
        {
            _aluno = new Aluno();
            _ServGerarCodigoEntidade = new ServGerarCodigoEntidade();

        }
        
        [TestFixtureSetUp]
        public void TesteInicial()
        {
            _repositorioEntidadeCodigo = new RepositorioEntidadeSequencial();

            _entidadeSequencial = _repositorioEntidadeCodigo.ObterPoNome(_aluno.GetType().Name);
            if (_entidadeSequencial==null)
            {
                _entidadeSequencial = new EntidadeSequencial { Nome = _aluno.GetType().Name, UltimoCodigo = 100 };
                _repositorioEntidadeCodigo.Adicionar(_entidadeSequencial);
            }
        }
            
        
        [Test]
        public void TestarGerarMatriculaAluno()
        {
            _entidadeSequencial = _repositorioEntidadeCodigo.ObterPoNome(_aluno.GetType().Name);

            Int32 _matricula1 = _ServGerarCodigoEntidade.Executar(_aluno.GetType().Name);
            Int32 _matricula2 = _ServGerarCodigoEntidade.Executar(_aluno.GetType().Name);
            Int32 _esperado = _matricula1 + 1;

            Assert.AreEqual(_esperado, _matricula2);
        }

    }
}
