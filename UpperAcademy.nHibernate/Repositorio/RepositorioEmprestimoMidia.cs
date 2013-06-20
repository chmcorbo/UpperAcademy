using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Dominio.Repositorios;

namespace UpperAcademy.Persistence.nHibernate.Repositorio
{
    public class RepositorioEmprestimoMidia : RepositorioGenerico<EmprestimoMidia>, IRepositorioEmprestimoMidia
    {
        public IList<EmprestimoMidia> ListarEmprestimos()
        {
            IQueryOver<EmprestimoMidia> queryOver =
                Session.QueryOver<EmprestimoMidia>().Where(e => e.Data_Devolucao == null);

            IList<EmprestimoMidia> listaEmprestimosMidias = queryOver.List<EmprestimoMidia>();

            return listaEmprestimosMidias;
        }


        public EmprestimoMidia ObterEmprestimoMidia(String pId_Midia)
        {
            IQueryOver<EmprestimoMidia> queryOver =
                Session.QueryOver<EmprestimoMidia>().Where(e => e.Midia.ID == pId_Midia && e.Data_Devolucao == null);

            return queryOver.List<EmprestimoMidia>().FirstOrDefault();
        }
    }
}
