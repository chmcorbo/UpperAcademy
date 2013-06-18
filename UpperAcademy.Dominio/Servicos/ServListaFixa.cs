using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpperAcademy.Dominio.Servicos
{
    public class ServListaFixa
    {
        protected Dictionary<Int16, String> ListaValoresFixo {get; set;}

        public ServListaFixa()
        {
            ListaValoresFixo = new Dictionary<Int16, String>();
        }

        public String ObterPelaChave(Int16 pNumero)
        {
            String retorno = String.Empty;

            if (ListaValoresFixo.ContainsKey(pNumero))
                retorno = ListaValoresFixo[pNumero];

            return retorno;
        }

        public List<String> Listar()
        {
            List<String> lista = new List<string>();

            foreach (KeyValuePair<Int16, String> item in ListaValoresFixo)
                lista.Add(item.Value);

            return lista;
        }

    }
}
