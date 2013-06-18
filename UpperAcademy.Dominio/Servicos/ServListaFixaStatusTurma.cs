using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpperAcademy.Dominio.Servicos
{
    public class ServListaFixaStatusTurma : ServListaFixa
    {
        public ServListaFixaStatusTurma() : base()
        {
            ListaValoresFixo.Add(1, "Aberta");
            ListaValoresFixo.Add(2, "Em andamento");
            ListaValoresFixo.Add(3, "Encerrada");
        }
    }
}
