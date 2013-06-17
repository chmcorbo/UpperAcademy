using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Enumerados;

namespace UpperAcademy.Dominio.Modelo
{
    public class Turma : EntidadeBase
    {
        private StatusTurma _status;
        private DateTime? _data_inicio;
        private DateTime? _data_fim;

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
        
        public virtual Int32 Nivel { get; set; }
        public virtual Professor Professor {get; set; }
        public virtual IList<Aluno> Alunos { get; set; }
        public virtual StatusTurma Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public Turma()
        {
            Alunos = new List<Aluno>();
            _status = StatusTurma.Aberta;
        }

        protected virtual void SetStatus()
        {
            if (DateTime.Now.Date >= _data_inicio && DateTime.Now.Date <= _data_fim)
                _status = StatusTurma.EmAndamento;
            else if (DateTime.Now.Date >= _data_fim)
                _status = StatusTurma.Encerrada;
        }

    }
}
