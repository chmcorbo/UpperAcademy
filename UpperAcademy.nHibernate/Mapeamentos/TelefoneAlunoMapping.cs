using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using UpperAcademy.Dominio.Modelo;

namespace UpperAcademy.Persistence.nHibernate.Mapeamentos
{
    public class TelefoneAlunoMapping : ClassMap<TelefoneAluno>
    {
        public TelefoneAlunoMapping()
        {
            Id(t => t.ID).Length(40);
            Map(t => t.TipoTelefone).Column("Tipo");
            Map(t => t.Numero).Length(12);

            References(a => a.Aluno).Cascade.None(); 
            Table("TB_TELEFONE_ALUNO");
        }
    }
}
