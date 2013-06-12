using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Modelo;

namespace UpperAcademy.Dominio.Servicos
{
    public interface IServDevolverMidia
    {
        Boolean Executar(Midia pMidia, DateTime pDataDevolucao);
    }
}
