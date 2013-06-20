using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Dominio.Servicos;
using UpperAcademy.Persistence.nHibernate.Repositorio;

namespace UpperAcademy.Persistence.nHibernate.Servicos
{
    public class ServAlocarProfessor : IServAlocarProfessor
    {
        private RepositorioGenerico<Turma> repositorioTurma;
        private RepositorioGenerico<Professor> repositorioProfessor;

        public ServAlocarProfessor()
        {
            repositorioTurma = new RepositorioGenerico<Turma>();
            repositorioProfessor = new RepositorioGenerico<Professor>();
        }

        public IServAlocarProfessor Executar(Turma pTurma, Professor pProfessor)
        {
            try
            {
                pProfessor.SetStatusAlocado();
                pTurma.Professor = pProfessor;
                repositorioProfessor.Atualizar(pProfessor);
                repositorioTurma.Atualizar(pTurma);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao tentar alocar professor em turma. " + e.Message);
            }
            return this;
        }
    }
}
