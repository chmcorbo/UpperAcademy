using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio;

namespace UpperAcademy.Dominio.Modelo
{
    public class TelefoneAluno : EntidadeBase
    {
        public virtual Aluno Aluno {get; set;}
        public virtual Int16 TipoTelefone { get; set; }
        public virtual String Numero { get; set; }

        public TelefoneAluno()
        {

        }

        public TelefoneAluno(Aluno pAluno, Int16 pTipoTelefone, String pNumero)
        {
            Aluno = pAluno;
            TipoTelefone = pTipoTelefone;
            Numero = pNumero;
        }
    }
}
