using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Modelo;

namespace UpperAcademy.Dominio.Repositorios
{
    public interface IRepositorioProfessor
    {
        IList<Professor> ListarPorNome(String pNome);
        IList<Professor> ListarPorNomeExcetoAlocadoTurma(String pNome, Turma pTurma);
    }
}
