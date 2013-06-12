using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpperAcademy.Dominio.Modelo
{
    public class EmprestimoMidia : EntidadeBase
    {
        public virtual DateTime? Data_Emprestimo {get; set;}
        public virtual DateTime? Data_Devolucao {get; set;}
        public virtual Midia Midia { get; set; }
        public virtual Aluno Aluno { get; set; }
    }
}
