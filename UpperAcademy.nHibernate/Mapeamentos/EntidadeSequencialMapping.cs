using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Persistence.nHibernate.Modelo;
using FluentNHibernate.Mapping;

namespace UpperAcademy.Persistence.nHibernate.Mapeamentos
{
    public class EntidadeSequencialMapping : ClassMap<EntidadeSequencial>
    {
        public EntidadeSequencialMapping()
        {
            Id(e => e.ID).Length(40);
            Map(e => e.Nome).Length(50);
            Map(e => e.UltimoCodigo);
            Table("TB_ENTIDADE_CODIGO");
        }
    }
}
