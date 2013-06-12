using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using UpperAcademy.Persistence.nHibernate.Repositorio;
using UpperAcademy.Dominio.Modelo;

namespace UpperAcademy.Testes.Repositorios
{
    [TestFixture]
    public class ProfessorTeste
    {
        Professor professor;
        Professor professorRecuperado;
        RepositorioGenerico<Professor> repositorio;
        String _id_professor;

        public ProfessorTeste()
        {
            repositorio = new RepositorioGenerico<Professor>();
        }

        [Test]
        public void a_Incluir_Professor_Sem_Endereco_Sem_Telefone()
        {
            professor = new Professor();
            _id_professor = professor.ID;
            professor.Nome = "Julio Mirilly";
            professor.Data_Nascimento = DateTime.Parse("08/12/1961");
            professor.Nivel = 2;

            repositorio.Atualizar(professor);

            professorRecuperado = repositorio.ObterPorID(_id_professor);
            Assert.AreSame(professor, professorRecuperado);
        }

        [Test]
        public void b_Incluir_Professor_Com_Endereco_Sem_Telefone()
        {
            professor = new Professor();
            _id_professor = professor.ID;
            professor.Nome = "Amarildo Cardoso";
            professor.Data_Nascimento = DateTime.Parse("22/09/1976");

            EnderecoProfessor endereco = new EnderecoProfessor(professor);
            endereco.Logradouro = "Av. das Américas";
            endereco.Numero = "168";
            endereco.Complemento = "Bl2 Ap206";
            endereco.Bairro = "Barra da Tijuca";
            endereco.Cidade = "Rio de Janeiro";
            endereco.UF = "RJ";
            endereco.CEP = "23983-890";
            professor.DefinirEndereco(endereco);

            repositorio.Atualizar(professor);
            professorRecuperado = repositorio.ObterPorID(_id_professor);
            Assert.AreSame(professor, professorRecuperado);
        }

        [Test]
        public void c_Incluir_Professor_Sem_Endereco_Com_Telefone()
        {
            professor = new Professor();
            _id_professor = professor.ID;
            professor.Nome = "Thiago Ferreira";
            professor.Data_Nascimento = DateTime.Parse("11/03/1973");

            professor.AdicionarTelefone(1, "21-2133-7577");
            professor.AdicionarTelefone(2, "21-8880-3351");
            professor.AdicionarTelefone(2, "21-7811-2633");

            repositorio.Atualizar(professor);
            professorRecuperado = repositorio.ObterPorID(_id_professor);
            Assert.AreSame(professor, professorRecuperado);
        }

        [Test]
        public void d_Incluir_Professor_Com_Endereco_Com_Telefone()
        {
            professor = new Professor();
            _id_professor = professor.ID;
            professor.Nome = "Rafael Torah Racile";
            professor.Data_Nascimento = DateTime.Parse("30/04/1966");

            EnderecoProfessor endereco = new EnderecoProfessor(professor);
            endereco.Logradouro = "Rua Santana de Assis Pereira";
            endereco.Numero = "2";
            endereco.Complemento = "Fundos";
            endereco.Bairro = "Bangu";
            endereco.Cidade = "Rio de Janeiro";
            endereco.UF = "RJ";
            endereco.CEP = "22449-122";
            professor.DefinirEndereco(endereco);
            professor.AdicionarTelefone(1, "21-3977-7587");
            professor.AdicionarTelefone(2, "21-9987-0922");

            repositorio.Atualizar(professor);
            professorRecuperado = repositorio.ObterPorID(_id_professor);
            Assert.AreSame(professor, professorRecuperado);
        }
    }
}
