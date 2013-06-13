using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpperAcademy.Persistence.nHibernate.Repositorio
{
    public class Banco
    {
        public static bool gerarBanco()
        {
            try
            {
                FluentSessionFactory.AbrirSession(true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
