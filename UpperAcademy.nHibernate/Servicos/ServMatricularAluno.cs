using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Dominio.Servicos;
using UpperAcademy.Persistence.nHibernate.Repositorio;
using UpperAcademy.Persistence.nHibernate.Modelo;

namespace UpperAcademy.Persistence.nHibernate.Servicos
{
    public class ServMatricularAluno : IServMatricularAluno
    {
        private RepositorioAluno repositorioAluno;
        private RepositorioGenerico<Turma> repositorioTurma;
        private RepositorioEntidadeSequencial repositorioEntidadeCodigo;
        private ServGerarCodigoEntidade servGerarCodigoEntidade;


        public ServMatricularAluno()
        {
            repositorioEntidadeCodigo = new RepositorioEntidadeSequencial();
            repositorioAluno = new RepositorioAluno();
            repositorioTurma = new RepositorioGenerico<Turma>();
            servGerarCodigoEntidade = new ServGerarCodigoEntidade();
        }

        public IServMatricularAluno Executar(Turma pTurma, Aluno pAluno)
        {
            try
            {
                if (pAluno.Matricula == String.Empty || pAluno.Matricula==null)
                {
                    String matriculaAluno = servGerarCodigoEntidade.Executar(pAluno.GetType().Name).ToString();
                    pAluno.Matricula = matriculaAluno;
                }
                pAluno.StatusMatriculado();
                repositorioAluno.Atualizar(pAluno);
                pTurma.Alunos.Add(pAluno);
                repositorioTurma.Atualizar(pTurma);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao tentar matricular o aluno. "+e.Message);
            }

            return this;
        }
    }
}
