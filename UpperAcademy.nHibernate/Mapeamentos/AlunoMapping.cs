using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Dominio.Enumerados;

namespace UpperAcademy.Persistence.nHibernate.Mapeamentos
{
    public class AlunoMapping : ClassMap<Aluno>
    {
        public AlunoMapping()
        {
            Id(a => a.ID).Length(40);
            Map(a => a.Matricula).Length(6);
            Map(a => a.Nome).Length(50);
            Map(a => a.Data_Nascimento).Column("Dt_Nascimento").CustomType("date");
            Map(a => a.Status);

            References(e => e.Endereco).Column("Id_Endereco").Cascade.All();
            References(t1 => t1.TelefoneResidencial).Column("Id_Telefone_Res").Cascade.All();
            References(t2 => t2.TelefoneComercial).Column("Id_Telefone_Com").Cascade.All();
            References(t3 => t3.TelefoneCelular).Column("Id_Telefone_Cel").Cascade.All();
            
            //HasMany(t => t.Telefones).Cascade.All();
            Table("TB_ALUNO");
        }
    }
}
