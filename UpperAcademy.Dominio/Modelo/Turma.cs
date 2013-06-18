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
        private DateTime? _data_inicio;
        private DateTime? _data_fim;
        private ServListaFixaStatusTurma _ServListaFixaStatusTurma;

        public virtual DateTime? Data_inicio
        {
            get { return _data_inicio; }
            set 
            { 
                _data_inicio = value;
                SetStatus();
            }
        }
        public virtual DateTime? Data_fim
        {
            get { return _data_fim; }
            set 
            { 
                _data_fim = value;
                SetStatus();
            }
        }
        
        public virtual Int16 Nivel { get; set; }
        public virtual Professor Professor {get; set; }
        public virtual IList<Aluno> Alunos { get; set; }
        public virtual String Status {get; protected set;}

        public Turma()
        {
            Alunos = new List<Aluno>();
            _ServListaFixaStatusTurma = new ServListaFixaStatusTurma();
            Status = _ServListaFixaStatusTurma.ObterPelaChave(1);
        }

        protected virtual void SetStatus()
        {
            if (DateTime.Now.Date >= _data_inicio && DateTime.Now.Date <= _data_fim)
                Status = _ServListaFixaStatusTurma.ObterPelaChave(2);
            else if (DateTime.Now.Date >= _data_fim)
                Status = _ServListaFixaStatusTurma.ObterPelaChave(3);
        }
    }
}
