using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Persistence.nHibernate.Modelo;
using NHibernate;


namespace UpperAcademy.Persistence.nHibernate.Repositorio
{
    public class RepositorioEntidadeSequencial : RepositorioGenerico<EntidadeSequencial>
    {
        public EntidadeSequencial ObterPoNome(String pNomeEntidade)
        {
            IQueryOver<EntidadeSequencial> queryOver = Session.QueryOver<EntidadeSequencial>().Where(e => e.Nome==pNomeEntidade);
            EntidadeSequencial entidadeSequencial = queryOver.List<EntidadeSequencial>().FirstOrDefault();
            return entidadeSequencial;
        }
    }
}
