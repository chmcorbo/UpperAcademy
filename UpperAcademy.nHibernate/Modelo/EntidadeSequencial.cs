using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio;

namespace UpperAcademy.Persistence.nHibernate.Modelo
{
    public class EntidadeSequencial : EntidadeBase
    {
        public virtual String Nome { get; set; }
        public virtual Int32 UltimoCodigo { get; set; }
    }
}
