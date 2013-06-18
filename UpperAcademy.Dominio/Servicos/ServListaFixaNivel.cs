using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpperAcademy.Dominio.Servicos
{
    public class ServListaFixaNivel : ServListaFixa
    {
        public ServListaFixaNivel() : base()
        {
            ListaValoresFixo.Add(1, "Básico");
            ListaValoresFixo.Add(2, "Intermediário");
            ListaValoresFixo.Add(3, "Avançado");
        }
    }
}
