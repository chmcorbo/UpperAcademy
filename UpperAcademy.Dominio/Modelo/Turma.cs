using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Enumerados;
using UpperAcademy.Dominio.Servicos;


namespace UpperAcademy.Dominio.Modelo
{
    public class Turma : EntidadeBase
    {
        private ServListaFixaStatusTurma _ServListaFixaStatusTurma;
        private ServListaFixaNivel _ServListaFixaNivel;

        public virtual DateTime? Data_inicio {get; set;}
        public virtual DateTime? Data_fim { get; set;}
        public virtual Int16 Nivel { get; set; }
        public virtual Professor Professor { get; set;}
        public virtual IList<Aluno> Alunos { get; set; }
        public virtual String Status
        {
            get
            {
                return AtualizaStatus();
            }
        }
        public virtual String Descricao_Nivel
        {
            get
            {
                return _ServListaFixaNivel.ObterPelaChave(Nivel);
            }
        }

        public Turma()
        {
            Alunos = new List<Aluno>();
            _ServListaFixaStatusTurma = new ServListaFixaStatusTurma();
            _ServListaFixaNivel = new ServListaFixaNivel();
        }

        protected virtual String AtualizaStatus()
        {
            String resultado = _ServListaFixaStatusTurma.ObterPelaChave(1);

            if (DateTime.Now.Date >= Data_inicio && DateTime.Now.Date <= Data_fim)
                resultado = _ServListaFixaStatusTurma.ObterPelaChave(2);
            else if (DateTime.Now.Date >= Data_fim)
                resultado = _ServListaFixaStatusTurma.ObterPelaChave(3);

            return resultado;
        }
    }
}
