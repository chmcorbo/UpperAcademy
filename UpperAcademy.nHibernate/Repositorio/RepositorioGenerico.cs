using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using UpperAcademy.Dominio;
using UpperAcademy.Dominio.Repositorios;

namespace UpperAcademy.Persistence.nHibernate.Repositorio
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T: EntidadeBase 
    {
        HybridSessionBuilder _builder = new HybridSessionBuilder();

        private ISession _session;
        protected virtual ISession Session
        {
            get
            {
                if (_builder == null)
                    _builder = new HybridSessionBuilder();

                return _session ?? (_session = _builder.GetSession());
            }
        }

        public void Adicionar(T pEntidadeBase)
        {
            ITransaction transaction = Session.BeginTransaction();
            try
            {
                Session.SaveOrUpdate(pEntidadeBase);
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception("Erro ao inserir ou atualizar o registro. " + Environment.NewLine + e.Message);
            }
            finally
            {
                transaction.Dispose();
            }

        }

        public void Atualizar(T pEntidadeBase)
        {
            this.Adicionar(pEntidadeBase);
        }

        public void Excluir(T pEntidadeBase)
        {
            ITransaction transaction = Session.BeginTransaction();
            try
            {
                Session.Delete(pEntidadeBase);
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception("Erro ao excluir o registro. " + Environment.NewLine + e.Message);
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public IQueryable<T> ListarTudo()
        {
            return Session.CreateCriteria(typeof(T)).List<T>().AsQueryable();
        }

        public T ObterPorID(String pID)
        {
            IQueryOver<T> queryOver = _session.QueryOver<T>().Where(t => t.ID == pID);
            return queryOver.List<T>().FirstOrDefault();
        }
    }
}
