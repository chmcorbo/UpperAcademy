using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Dominio.Enumerados;
using UpperAcademy.Persistence.nHibernate.Repositorio;
using NUnit.Framework;


namespace UpperAcademy.Testes.Repositorios
{
    [TestFixture]
    public class TurmaTeste
    {
        private RepositorioGenerico<Turma> repositorio;
        private RepositorioGenerico<Professor> repositorioProfessor;
        private RepositorioAluno repositorioAluno;
        private Turma turma;
        private Turma turmaRecuperada;

        public TurmaTeste()
        {
            repositorio = new RepositorioGenerico<Turma>();
            repositorioAluno = new RepositorioAluno();
            repositorioProfessor = new RepositorioGenerico<Professor>();
        }

        public Boolean Carga_Inicial()
        {
            Boolean erro = false;

            try
            {
                turma = new Turma();
                turma.Nivel = 1;
                turma.Data_inicio = DateTime.Parse("01/07/2013 18:30:00");
                turma.Data_fim = DateTime.Parse("15/07/2013 21:30:00");
                repositorio.Adicionar(turma);

                turma = new Turma();
                turma.Nivel = 1;
                turma.Data_inicio = DateTime.Parse("17/06/2013 09:30:00");
                turma.Data_fim = DateTime.Parse("05/07/2013 12:00:00");
                repositorio.Adicionar(turma);

                turma = new Turma();
                turma.Nivel = 1;
                turma.Data_inicio = DateTime.Parse("22/07/2013 13:30:00");
                turma.Data_fim = DateTime.Parse("09/08/2013 17:00:00");
                repositorio.Adicionar(turma);

                turma = new Turma();
                turma.Nivel = 2;
                turma.Data_inicio = DateTime.Parse("05/08/2013 18:30:00");
                turma.Data_fim = DateTime.Parse("16/08/2013 21:30:00");
                repositorio.Adicionar(turma);
            }
            catch (Exception e)
            {
                erro = true;
                throw new Exception("Erro ao fazer a carga inicial" + e.Message);
            }
            return !erro;

        }


        [Test]
        public void Incluir_Turma()
        {
            turma = new Turma();
            turma.Nivel = 1;
            turma.Data_inicio = DateTime.Parse("02/09/2013 18:30:00");
            turma.Data_fim = DateTime.Parse("25/10/2013 21:30:00");
            repositorio.Adicionar(turma);

            turmaRecuperada = repositorio.ObterPorID(turma.ID);
            Assert.AreSame(turma, turmaRecuperada);
        }

    }

}
