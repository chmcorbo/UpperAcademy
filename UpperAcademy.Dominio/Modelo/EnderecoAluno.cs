using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio;

namespace UpperAcademy.Dominio.Modelo
{
    public class EnderecoAluno : EntidadeBase
    {
        public virtual Aluno Aluno { get; set; }
        public virtual String Logradouro { get; set; }
        public virtual String Numero { get; set; }
        public virtual String Complemento { get; set; }
        public virtual String Bairro { get; set; }
        public virtual String Cidade { get; set; }
        public virtual String UF { get; set; }
        public virtual String CEP { get; set; }

        public EnderecoAluno()
        {

        }

        public EnderecoAluno(Aluno pAluno)
        {
            this.Aluno = pAluno;
        }
    }
}
