using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Modelo;

namespace UpperAcademy.Dominio.Repositorios
{
    public interface IRepositorioEmprestimoMidia : IRepositorioGenerico<EmprestimoMidia>
    {
        IList<EmprestimoMidia> ListarMidiasEmprestadas();
    }
}
