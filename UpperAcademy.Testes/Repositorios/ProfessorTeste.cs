using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using UpperAcademy.Persistence.nHibernate.Repositorio;
using UpperAcademy.Dominio.Modelo;
using UpperAcademy.Dominio.Enumerados;

namespace UpperAcademy.Testes.Repositorios
{
    [TestFixture]
    public class ProfessorTeste
    {
        Professor _professor;
        Professor _professorRecuperado;
        RepositorioGenerico<Professor> _repositorio;

        public ProfessorTeste()
        {
            _repositorio = new RepositorioGenerico<Professor>();
        }

        private Professor Incluir_Sem_Endereco_Sem_Telefone()
        {
            Professor professor = new Professor();
            professor.Nome = "Julio Mirilly";
            professor.Data_Nascimento = DateTime.Parse("08/12/1961");
            professor.Nivel = cNivel.Intermadiario;
            _repositorio.Atualizar(professor);
            return professor;
        }

        private Professor Incluir_Com_Endereco_Sem_Telefone()
        {
            Professor professor = new Professor();
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
            _repositorio.Atualizar(professor);
            return professor;
        }

        private Professor Incluir_Sem_Endereco_Com_Telefone()
        {
            Professor professor = new Professor();
            professor.Nome = "Thiago Ferreira";
            professor.Data_Nascimento = DateTime.Parse("11/03/1973");

            professor.DefinirTelefoneResidencial("21-2133-7577");
            professor.DefinirTelefoneComercial("21-2380-3351");
            professor.DefinirTelefoneCelular("21-7811-2633");

            _repositorio.Atualizar(professor);

            return professor;
        }

        private Professor Incluir_Com_Endereco_Com_Telefone()
        {
            Professor professor = new Professor();

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
            professor.DefinirTelefoneResidencial("21-3977-7587");
            professor.DefinirTelefoneCelular("21-9987-0922");

            _repositorio.Atualizar(professor);

            return professor;
        }

        public Boolean Carga_Inicial()
        {
            Boolean erro = false;

            try
            {
                Incluir_Sem_Endereco_Sem_Telefone();
                Incluir_Com_Endereco_Sem_Telefone();
                Incluir_Sem_Endereco_Com_Telefone();
                Incluir_Com_Endereco_Com_Telefone();
            }
            catch (Exception e)
            {
                erro = true;
                throw new Exception("Erro ao fazer a carga inicial" + e.Message);
            }
            return !erro;
        }

        [Test]
        public void a_Incluir_Sem_Endereco_Sem_Telefone()
        {
            _professor = Incluir_Sem_Endereco_Sem_Telefone();
            _professorRecuperado = _repositorio.ObterPorID(_professor.ID);
            Assert.AreSame(_professor, _professorRecuperado);
        }

        [Test]
        public void b_Incluir_Com_Endereco_Sem_Telefone()
        {
            _professor = Incluir_Com_Endereco_Sem_Telefone();
            _professorRecuperado = _repositorio.ObterPorID(_professor.ID);
            Assert.AreSame(_professor, _professorRecuperado);
        }

        [Test]
        public void c_Incluir_Sem_Endereco_Com_Telefone()
        {
            _professor = Incluir_Sem_Endereco_Com_Telefone();

            _professorRecuperado = _repositorio.ObterPorID(_professor.ID);
            Assert.AreSame(_professor, _professorRecuperado);
        }

        [Test]
        public void d_Incluir_Com_Endereco_Com_Telefone()
        {
            _professor = Incluir_Com_Endereco_Com_Telefone();
            _professorRecuperado = _repositorio.ObterPorID(_professor.ID);
            Assert.AreSame(_professor, _professorRecuperado);
        }
    }
}
