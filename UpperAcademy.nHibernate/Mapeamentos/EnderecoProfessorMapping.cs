using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using UpperAcademy.Dominio.Modelo;

namespace UpperAcademy.Persistence.nHibernate.Mapeamentos
{
    public class EnderecoProfessorMapping : ClassMap<EnderecoProfessor>
    {
        public EnderecoProfessorMapping()
        {
            Id(e => e.ID).Length(40);
            Map(e => e.Logradouro).Length(50);
            Map(e => e.Numero).Length(10);
            Map(e => e.Complemento).Length(10);
            Map(e => e.Bairro).Length(30);
            Map(e => e.Cidade).Length(50);
            Map(e => e.UF).Length(2);
            Map(e => e.CEP).Length(10);

            References(p => p.Professor).Column("Id_Professor").Cascade.None();
            Table("TB_ENDERECO_PROFESSOR");
        }
    }
}
