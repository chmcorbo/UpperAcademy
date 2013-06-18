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
        private RepositorioGenerico<Aluno> repositorioAluno;
        private Turma turma;
        private Turma turmaRecuperada;

        public TurmaTeste()
        {
            repositorio = new RepositorioGenerico<Turma>();
            repositorioAluno = new RepositorioGenerico<Aluno>();
            repositorioProfessor = new RepositorioGenerico<Professor>();
        }

        private void Incluir_Alunos()
        {
            Aluno aluno = new Aluno();
            aluno.Nome = "Amarildo Cardoso";
            aluno.Data_Nascimento = DateTime.Parse("22/09/1961");

            EnderecoAluno endereco = new EnderecoAluno(aluno);
            endereco.Logradouro = "Rodovia Amaral Peixoto";
            endereco.Numero = "772";
            endereco.Complemento = "Casa 10";
            endereco.Bairro = "Centro";
            endereco.Cidade = "Marica";
            endereco.UF = "RJ";
            endereco.CEP = "20009-110";
            aluno.DefinirEndereco(endereco);

            repositorioAluno.Atualizar(aluno);
            /******************************************************/
            aluno = new Aluno();
            aluno.Nome = "William Rego";
            aluno.Data_Nascimento = DateTime.Parse("13/02/1979");

            endereco = new EnderecoAluno(aluno);
            endereco.Logradouro = "Rua Santana de Assis Pereira";
            endereco.Numero = "2";
            endereco.Complemento = "Fundos";
            endereco.Bairro = "Bangu";
            endereco.Cidade = "Rio de Janeiro";
            endereco.UF = "RJ";
            endereco.CEP = "22449-122";
            aluno.DefinirEndereco(endereco);
            aluno.DefinirTelefoneResidencial("21-3977-7587");
            aluno.DefinirTelefoneCelular("21-9987-0922");
            repositorioAluno.Atualizar(aluno);
        }

        private void Incluir_Professores()
        {
            Professor professor = new Professor();

            professor.Nome = "Rafael Torah Racile";
            professor.Data_Nascimento = DateTime.Parse("30/04/1966");
            professor.Nivel =cNivel.Intermadiario;
            professor.DefinirTelefoneResidencial("21-2133-7577");
            professor.DefinirTelefoneComercial("21-3977-7587");
            professor.DefinirTelefoneCelular("21-9987-0922");

            EnderecoProfessor endereco = new EnderecoProfessor(professor);
            endereco.Logradouro = "Rua Santana de Assis Pereira";
            endereco.Numero = "2";
            endereco.Complemento = "Fundos";
            endereco.Bairro = "Bangu";
            endereco.Cidade = "Rio de Janeiro";
            endereco.UF = "RJ";
            endereco.CEP = "22449-122";
            professor.DefinirEndereco(endereco);

            repositorioProfessor.Atualizar(professor);
            /**************************************************/
            professor = new Professor();
            professor.Nome = "Amarildo Cardoso";
            professor.Data_Nascimento = DateTime.Parse("22/09/1976");
            professor.DefinirTelefoneResidencial("21-2880-3351");
            professor.DefinirTelefoneCelular("21-7811-2633");

            endereco = new EnderecoProfessor(professor);
            endereco.Logradouro = "Av. das Américas";
            endereco.Numero = "168";
            endereco.Complemento = "Bl2 Ap206";
            endereco.Bairro = "Barra da Tijuca";
            endereco.Cidade = "Rio de Janeiro";
            endereco.UF = "RJ";
            endereco.CEP = "23983-890";
            professor.DefinirEndereco(endereco);

            repositorioProfessor.Atualizar(professor);
            /**************************************************/
        }

        [Test]
        public void Incluir_Turma_Sem_Aluno_Sem_Professor()
        {
            turma = new Turma();
            turma.Nivel = 1;
            turma.Data_inicio = DateTime.Parse("01/07/2013 18:30:00");
            turma.Data_fim = DateTime.Parse("15/07/2013 21:30:00");
            repositorio.Atualizar(turma);

            turmaRecuperada = repositorio.ObterPorID(turma.ID);

            Assert.AreSame(turma, turmaRecuperada);
        }

        [Test]
        public void Incluir_Turma_Com_Aluno_Sem_Professor()
        {
            turma = new Turma();
            turma.Nivel = 1;
            turma.Data_inicio = DateTime.Parse("17/06/2013 09:30:00");
            turma.Data_fim = DateTime.Parse("05/07/2013 12:00:00");

            Incluir_Alunos();

            List<Aluno> alunos = repositorioAluno.ListarTudo().ToList();

            turma.Alunos = alunos;

            repositorio.Atualizar(turma);
            turmaRecuperada = repositorio.ObterPorID(turma.ID);

            Assert.AreSame(turma, turmaRecuperada);

        }

        [Test]
        public void Incluir_Turma_Com_Professor_Sem_Aluno()
        {
            turma = new Turma();
            turma.Nivel = 1;
            turma.Data_inicio = DateTime.Parse("22/07/2013 13:30:00");
            turma.Data_fim = DateTime.Parse("09/08/2013 17:00:00");

            Incluir_Professores();

            List<Professor> professores = repositorioProfessor.ListarTudo().ToList();

            turma.Professor = professores.FirstOrDefault();

            repositorio.Atualizar(turma);
            turmaRecuperada = repositorio.ObterPorID(turma.ID);

            Assert.AreSame(turma, turmaRecuperada);
        }

        [Test]
        public void Incluir_Turma_Com_Professor_e_Aluno()
        {
            turma = new Turma();
            turma.Nivel = 2;
            turma.Data_inicio = DateTime.Parse("05/08/2013 18:30:00");
            turma.Data_fim = DateTime.Parse("16/08/2013 21:30:00");

            List<Aluno> alunos = repositorioAluno.ListarTudo().ToList();
            List<Professor> professores = repositorioProfessor.ListarTudo().ToList();

            if (alunos.Count==0)
            {
                Incluir_Alunos();
                alunos = repositorioAluno.ListarTudo().ToList();
            }

            if (professores.Count==0)
            {
                Incluir_Professores();
                professores = repositorioProfessor.ListarTudo().ToList();
            }

            turma.Alunos = alunos;
            turma.Professor = professores.FirstOrDefault();

            repositorio.Atualizar(turma);
            turmaRecuperada = repositorio.ObterPorID(turma.ID);

            Assert.AreSame(turma, turmaRecuperada);
        }


    }

}
