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
            Map(p => p.Data_Nascimento).Column("Dt_Nascimento").CustomType("date");
            Map(p => p.Nivel).Length(20);
            Map(p => p.Status).Length(10);

            References(p => p.Endereco).Column("Id_Endereco").Cascade.All();
            References(t1 => t1.TelefoneResidencial).Column("Id_Telefone_Res").Cascade.All();
            References(t2 => t2.TelefoneComercial).Column("Id_Telefone_Com").Cascade.All();
            References(t3 => t3.TelefoneCelular).Column("Id_Telefone_Cel").Cascade.All();

            //HasMany(p => p.Telefones).Cascade.All();
            Table("TB_PROFESSOR");
        }
    }
}
