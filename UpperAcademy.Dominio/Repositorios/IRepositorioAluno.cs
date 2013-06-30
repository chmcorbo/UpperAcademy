using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Modelo;

namespace UpperAcademy.Dominio.Repositorios
{
    public interface IRepositorioAluno
    {
        IList<Aluno> ListarPorNome(String pNome);
    }
}
