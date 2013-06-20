using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace UpperAcademy.Dominio.Servicos
{
    public class ServListaFixaStatusProfessor : ServListaFixa
    {
        public ServListaFixaStatusProfessor()
            : base()
        {
            ListaValoresFixo.Add(1, "Disponível");
            ListaValoresFixo.Add(2, "Alocado");
        }
    }
}
