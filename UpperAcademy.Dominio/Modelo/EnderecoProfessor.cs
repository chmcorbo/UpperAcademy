using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpperAcademy.Dominio.Modelo
{
    public class EnderecoProfessor : EntidadeBase
    {
        public virtual Professor Professor { get; set; }
        public virtual String Logradouro { get; set; }
        public virtual String Numero { get; set; }
        public virtual String Complemento { get; set; }
        public virtual String Bairro { get; set; }
        public virtual String Cidade { get; set; }
        public virtual String UF { get; set; }
        public virtual String CEP { get; set; }

        public EnderecoProfessor()
        {

        }

        public EnderecoProfessor(Professor pProfessor)
        {
            this.Professor = pProfessor;
        }


    }
}
