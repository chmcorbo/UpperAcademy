using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Persistence.nHibernate.Repositorio;
using UpperAcademy.Dominio.Modelo;
using NUnit.Framework;

namespace UpperAcademy.Testes.Repositorios
{
  
    [TestFixture]
    public class AlunoTeste
    {
        Aluno aluno;
        Aluno alunoRecuperado;
        RepositorioGenerico<Aluno> repositorio;
        String _id_aluno;

        
        public AlunoTeste()
        {
            repositorio = new RepositorioGenerico<Aluno>();
        }

        public void Incluir_Alunos()
        {
            aluno = new Aluno();
            _id_aluno = aluno.ID;
            aluno.Nome = "Joel Amoras Dias";
            aluno.Data_Nascimento = DateTime.Parse("08/12/1976");
            repositorio.Atualizar(aluno);
            /********************************************************************/
            aluno = new Aluno();
            _id_aluno = aluno.ID;
            aluno.Nome = "Paulo Silva Doria";
            aluno.Data_Nascimento = DateTime.Parse("25/03/1971");
            repositorio.Atualizar(aluno);
        }
        

        [Test]
        public void a_Incluir_Aluno_Sem_Endereco_Sem_Telefone()
        {
            aluno = new Aluno();
            _id_aluno = aluno.ID;
            aluno.Nome="Jose Henrique de Souza";
            aluno.Data_Nascimento = DateTime.Parse("08/12/1976"); ;

            repositorio.Atualizar(aluno);

            alunoRecuperado = repositorio.ObterPorID(_id_aluno);
            Assert.AreSame(aluno,alunoRecuperado);
        }

        [Test]
        public void b_Incluir_Aluno_Com_Endereco_Sem_Telefone()
        {
            aluno = new Aluno();
            _id_aluno = aluno.ID;
            aluno.Nome = "Amarildo Cardoso";
            aluno.Data_Nascimento = DateTime.Parse("22/09/1961");

            EnderecoAluno endereco = new EnderecoAluno(aluno);
            endereco.Logradouro="Rodovia Amaral Peixoto";
            endereco.Numero = "772";
            endereco.Complemento = "Casa 10";
            endereco.Bairro = "Centro";
            endereco.Cidade = "Marica";
            endereco.UF = "RJ";
            endereco.CEP = "20009-110";
            aluno.DefinirEndereco(endereco);

            repositorio.Atualizar(aluno);
            alunoRecuperado = repositorio.ObterPorID(_id_aluno);
            Assert.AreSame(aluno, alunoRecuperado);
        }

        [Test]
        public void c_Incluir_Aluno_Sem_Endereco_Com_Telefone()
        {
            aluno = new Aluno();
            _id_aluno = aluno.ID;
            aluno.Nome = "Thiago Ferreira";
            aluno.Data_Nascimento = DateTime.Parse("11/03/1980");

            aluno.AdicionarTelefone(1, "21-2133-7577");
            aluno.AdicionarTelefone(2, "21-8880-3351");
            aluno.AdicionarTelefone(2, "21-7811-2633");

            repositorio.Atualizar(aluno);
            alunoRecuperado = repositorio.ObterPorID(_id_aluno);
            Assert.AreSame(aluno, alunoRecuperado);
        }

        [Test]
        public void d_Incluir_Aluno_Com_Endereco_Com_Telefone()
        {
            aluno = new Aluno();
            _id_aluno = aluno.ID;
            aluno.Nome = "William Rego";
            aluno.Data_Nascimento = DateTime.Parse("13/02/1979");

            EnderecoAluno endereco = new EnderecoAluno(aluno);
            endereco.Logradouro = "Rua Santana de Assis Pereira";
            endereco.Numero = "2";
            endereco.Complemento = "Fundos";
            endereco.Bairro = "Bangu";
            endereco.Cidade = "Rio de Janeiro";
            endereco.UF = "RJ";
            endereco.CEP = "22449-122";
            aluno.DefinirEndereco(endereco);
            aluno.AdicionarTelefone(1, "21-3977-7587");
            aluno.AdicionarTelefone(2, "21-9987-0922");

            repositorio.Atualizar(aluno);
            alunoRecuperado = repositorio.ObterPorID(_id_aluno);
            Assert.AreSame(aluno, alunoRecuperado);
        }
    }
}
