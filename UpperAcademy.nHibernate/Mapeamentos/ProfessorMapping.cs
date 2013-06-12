using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using UpperAcademy.Dominio.Modelo;

namespace UpperAcademy.Persistence.nHibernate.Mapeamentos
{
    public class ProfessorMapping : ClassMap<Professor>
    {
        public ProfessorMapping()
        {
            Id(p => p.ID).Length(40);
            Map(p => p.Nome).Length(50);
            Map(p => p.Data_Nascimento).Column("Dt_Nascimento");
            Map(p => p.Nivel);

            References(p => p.Endereco).Cascade.All();
            HasMany(p => p.Telefones).Cascade.All();
            Table("TB_PROFESSOR");
        }
    }
}
