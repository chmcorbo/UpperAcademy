using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Persistence.nHibernate.Repositorio;
using UpperAcademy.Dominio.Servicos;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Dominio.Excecoes;

namespace UpperAcademy.Persistence.nHibernate.Servicos
{
    public class ServDevolverMidia : IServDevolverMidia
    {
        RepositorioEmprestimoMidia repositorioEmprestimoMidia;
        RepositorioGenerico<Midia> repositorioMidia;
        EmprestimoMidia emprestimoMidia;

        public ServDevolverMidia()
        {
            repositorioEmprestimoMidia = new RepositorioEmprestimoMidia();
            repositorioMidia = new RepositorioGenerico<Midia>();

        }
        public IServDevolverMidia Executar(String pId_Midia, DateTime pDataDevolucao)
        {
            emprestimoMidia = repositorioEmprestimoMidia.ObterEmprestimoMidia(pId_Midia);

            if (emprestimoMidia == null)
                throw new ExMidiaDevolvida("Midia já devolvida ou ela nunca foi emprestada");

            emprestimoMidia.Midia.Devolver(1);
            emprestimoMidia.Data_Devolucao = DateTime.Now;

            repositorioMidia.Atualizar(emprestimoMidia.Midia);

            repositorioEmprestimoMidia.Atualizar(emprestimoMidia);

            return this;
        }
    }
}
