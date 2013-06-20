using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpperAcademy.Dominio.Servicos
{
    public class ServListaFixaStatusAluno : ServListaFixa
    {
        public ServListaFixaStatusAluno()
            : base()
        {
            ListaValoresFixo.Add(1, "Cadastrado");
            ListaValoresFixo.Add(2, "Matriculado");
        }

    }
}
