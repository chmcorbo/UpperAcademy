using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpperAcademy.Dominio.Modelo
{
    public class TelefoneProfessor : EntidadeBase
    {
        public virtual Professor Professor {get; set;}
        public virtual Int16 TipoTelefone { get; set; }
        public virtual String Numero { get; set; }

        public TelefoneProfessor()
        {

        }

        public TelefoneProfessor(Professor pProfessor, Int16 pTipoTelefone, String pNumero)
        {
            Professor = pProfessor;
            TipoTelefone = pTipoTelefone;
            Numero = pNumero;
        }
    }
}
