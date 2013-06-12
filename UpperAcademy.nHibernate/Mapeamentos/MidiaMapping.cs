using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using UpperAcademy.Dominio.Modelo;

namespace UpperAcademy.Persistence.nHibernate.Mapeamentos
{
    public class MidiaMapping : ClassMap<Midia>
    {
        public MidiaMapping()
        {
            Id(m => m.ID).Index("PK_MIDIA").Length(40);
            Map(m => m.Descricao).Length(50);
            Map(m => m.Autor).Length(50);
            Map(m => m.Qtde_Copias);
            Map(m => m.Qtde_Disponivel);
            Table("TB_MIDIA");
        }
    }
}
