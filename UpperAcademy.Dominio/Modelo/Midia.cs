using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Excecoes;

namespace UpperAcademy.Dominio.Modelo
{
    public class Midia : EntidadeBase
    {
        public virtual String Descricao { get; set; }
        public virtual String Autor { get; set; }
        public virtual Int32 Qtde_Copias { get; set; }
        public virtual Int32 Qtde_Disponivel { get; set; }

        public virtual void Emprestar(Int32 pQuantidade = 1)
        {
            if (Qtde_Disponivel >= pQuantidade)
                Qtde_Disponivel = Qtde_Disponivel - pQuantidade;
            else
                throw new ExEmprestimoAcimaDoDisponivel("Não é possível empresar uma quantidade maior do que tem disponível. " + 
                    Environment.NewLine+" Qtde disponível:" + Qtde_Disponivel.ToString()+
                    Environment.NewLine+" Qtde a emprestar: "+pQuantidade.ToString());
        }

        public virtual void Devolver(Int32 pQuantidade)
        {
            if (pQuantidade>Qtde_Copias || (pQuantidade+Qtde_Disponivel)>Qtde_Copias)
                throw new ExDevolucaoAcimaQtdeCopias("Não é possível devolver uma quantidade acima da quantidade de cópias. "+
                    Environment.NewLine+"Qtde cópias: "+Qtde_Copias.ToString()+
                    Environment.NewLine+"Qtde disponível: "+Qtde_Disponivel.ToString()+
                    Environment.NewLine+"Qtde a devolver: "+pQuantidade.ToString());

            Qtde_Disponivel = Qtde_Disponivel + pQuantidade;
        }
    }
}
