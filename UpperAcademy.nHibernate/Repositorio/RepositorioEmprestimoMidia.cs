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
        public IList<EmprestimoMidia> ListarMidiasEmprestadas()
        {
            IQueryOver<EmprestimoMidia> queryOver =
                Session.QueryOver<EmprestimoMidia>().Where(e => e.Data_Devolucao == null);

            IList<EmprestimoMidia> listaEmprestimosMidias = queryOver.List<EmprestimoMidia>();

            return listaEmprestimosMidias;
        }
    }
}
