using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using UpperAcademy.Dominio.Modelo;

namespace UpperAcademy.Persistence.nHibernate.Mapeamentos
{
    public class TelefoneProfessorMapping : ClassMap<TelefoneProfessor>
    {
        public TelefoneProfessorMapping()
        {
            Id(t => t.ID).Column("Id").Length(40);
            Map(t => t.TipoTelefone).Column("Tipo");
            Map(t => t.Numero).Length(12);
            
            //References(t => t.Professor).Cascade.None();
            Table("TB_TELEFONE_PROFESSOR");
        }
    }
}
