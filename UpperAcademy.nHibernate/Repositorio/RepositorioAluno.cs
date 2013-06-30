using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Dominio.Repositorios;
using UpperAcademy.Dominio.Excecoes;
using NHibernate;

namespace UpperAcademy.Persistence.nHibernate.Repositorio
{
    public class RepositorioAluno : RepositorioGenerico<Aluno>, IRepositorioAluno
    {
        public IList<Aluno> ListarPorNome(String pNome)
        {
            IQueryOver<Aluno> queryOver = Session.QueryOver<Aluno>().WhereRestrictionOn(a => a.Nome).IsLike("%"+pNome+"%").OrderBy(a => a.Nome).Asc;
            return queryOver.List<Aluno>();
        }

        public IList<Aluno> ListarPorNomeExcetoMatriculadoTurma(String pNome, Turma pTurma)
        {
            IList<Aluno> listaAluno = ListarPorNome(pNome);

            return listaAluno.Except(pTurma.Alunos).ToList();
        }

        public override void Excluir(Aluno pAluno)
        {
            pAluno.TelefoneResidencial = null;
            pAluno.TelefoneComercial = null;
            pAluno.TelefoneCelular = null;
            pAluno.Endereco = null;
            RepositorioGenerico<Aluno> repositorioAluno = new RepositorioGenerico<Aluno>();
            repositorioAluno.Atualizar(pAluno);
            repositorioAluno.Excluir(pAluno);
        }

    }
}
