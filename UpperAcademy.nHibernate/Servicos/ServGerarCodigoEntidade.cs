using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Persistence.nHibernate.Modelo;
using UpperAcademy.Persistence.nHibernate.Repositorio;
using UpperAcademy.Dominio.Excecoes;


namespace UpperAcademy.Persistence.nHibernate.Servicos
{
    public class ServGerarCodigoEntidade
    {
        RepositorioEntidadeSequencial repositorioEntidadeCodigo;

        public ServGerarCodigoEntidade()
        {
            repositorioEntidadeCodigo = new RepositorioEntidadeSequencial();
        }

        public Int32 Executar(String pNomeEntidade)
        {
            EntidadeSequencial entidadeCodigo = repositorioEntidadeCodigo.ObterPoNome(pNomeEntidade);
            if (entidadeCodigo==null)
                throw new ExEntidadeSequencialNaoExiste("Entidade geradora de sequencial não existe. ");
            entidadeCodigo.UltimoCodigo++;
            repositorioEntidadeCodigo.Atualizar(entidadeCodigo);
            return entidadeCodigo.UltimoCodigo;
        }
    }
}
