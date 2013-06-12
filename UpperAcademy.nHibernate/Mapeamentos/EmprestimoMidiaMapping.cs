using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Modelo;
using FluentNHibernate.Mapping;

namespace UpperAcademy.Persistence.nHibernate.Mapeamentos
{
    public class EmprestimoMidiaMapping : ClassMap<EmprestimoMidia>
    {
        public EmprestimoMidiaMapping()
        {
            Id(e => e.ID).Length(40);
            Map(e => e.Data_Emprestimo).Column("Dt_Emprestimo");
            Map(e => e.Data_Devolucao).Column("Dt_Devolucao");
            References(e => e.Midia).Column("Id_Midia").Cascade.All();
            References(e => e.Aluno).Column("Id_Aluno").Cascade.All();
            Table("TB_EMPRESTIMO_MIDIA");
        }
    }
}
