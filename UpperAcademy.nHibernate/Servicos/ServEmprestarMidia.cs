using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Dominio.Servicos;
using UpperAcademy.Persistence.nHibernate.Repositorio;
using UpperAcademy.Dominio.Excecoes;

namespace UpperAcademy.Persistence.nHibernate.Servicos
{
    public class ServEmprestarMidia : IServEmprestarMidia
    {
        private RepositorioEmprestimoMidia repositorioEmprestimoMidia;
        private RepositorioGenerico<Midia> repositorioMidia;
        private EmprestimoMidia emprestimoMidia;

        public ServEmprestarMidia()
        {
            repositorioMidia = new RepositorioGenerico<Midia>();
            repositorioEmprestimoMidia = new RepositorioEmprestimoMidia();
        }

        public IServEmprestarMidia Executar(Midia pMidia, Aluno pAluno, DateTime pDataEmprestimo)
        {
            emprestimoMidia = new EmprestimoMidia();
            try
            {
                emprestimoMidia.Aluno = pAluno;
                emprestimoMidia.Midia = pMidia;
                emprestimoMidia.Data_Emprestimo = pDataEmprestimo;
                repositorioEmprestimoMidia.Adicionar(emprestimoMidia);

                pMidia.Emprestar(1);
                repositorioMidia.Atualizar(pMidia);
            }
            catch (Exception e)
            {
                throw new ExErroEmprestimoMidia("Erro ao fazer o empréstimo de uma mídia. " +Environment.NewLine+ e.Message);
            }

            return this;
        }
    }
}
