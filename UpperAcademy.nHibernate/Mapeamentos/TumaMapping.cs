using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using UpperAcademy.Dominio.Modelo;

namespace UpperAcademy.Persistence.nHibernate.Mapeamentos
{
    public class TumaMapping : ClassMap<Turma>
    {
        public TumaMapping()
        {
            Id(t => t.ID).Length(40);
            Map(t => t.Nivel).CustomType("smallint");
            Map(t => t.Data_inicio).Column("Dt_Inicio");
            Map(t => t.Data_fim).Column("Dt_Fim");
            References(t => t.Professor).Column("Id_Professor").Cascade.All();
            HasManyToMany(t => t.Alunos).Table("TB_ALUNO_TURMA");
            Table("TB_TURMA");
        }
    }
}
