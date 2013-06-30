using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UpperAcademy.Dominio.Modelo;

namespace UpperAcademy.Web.Models
{
    public class TurmaViewModel
    {
        public String NomePesquisa { get; set; }
        public Turma Turma { get; set; }
        public List<Aluno> ListaAlunos { get; set; }
        public List<Professor> ListaProfessores { get; set; }

        public TurmaViewModel()
        {
            NomePesquisa = String.Empty;
            ListaAlunos = new List<Aluno>();
            ListaProfessores = new List<Professor>();
        }
    }
}