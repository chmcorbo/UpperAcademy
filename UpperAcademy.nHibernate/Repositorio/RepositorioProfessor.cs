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
    public class RepositorioProfessor : RepositorioGenerico<Professor>, IRepositorioProfessor
    {
        public IList<Professor> ListarPorNome(String pNome)
        {
            IQueryOver<Professor> queryOver = Session.QueryOver<Professor>().WhereRestrictionOn(a => a.Nome).IsLike("%" + pNome + "%").OrderBy(a => a.Nome).Asc;

            return queryOver.List<Professor>();
        }

        public IList<Professor> ListarPorNomeExcetoAlocadoTurma(String pNome, Turma pTurma)
        {
            IList<Professor> listaProfessores = ListarPorNome(pNome);

            if (pTurma.Professor!=null)
                listaProfessores.Remove(pTurma.Professor);

            return listaProfessores.ToList();
        }
    }
}
