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
        Aluno _aluno;
        Aluno _alunoRecuperado;
        RepositorioAluno repositorio;
        
        public AlunoTeste()
        {
            repositorio = new RepositorioAluno();
        }

        private Aluno Incluir_Aluno_Sem_Endereco_Sem_Telefone()
        {
            Aluno aluno = new Aluno();

            aluno.Nome = "Jose Henrique de Souza";
            aluno.Data_Nascimento = DateTime.Parse("08/12/1976"); ;

            repositorio.Adicionar(aluno);
            return aluno;
        }

        private Aluno Incluir_Aluno_Com_Endereco_Sem_Telefone()
        {
            Aluno aluno = new Aluno();

            aluno.Nome = "Leticia Dutra";
            aluno.Data_Nascimento = DateTime.Parse("11/06/1974");

            EnderecoAluno endereco = new EnderecoAluno(aluno);
            endereco.Logradouro = "Rua Santa Alexandrina";
            endereco.Numero = "82";
            endereco.Complemento = "Apto 203";
            endereco.Bairro = "Rio Comprido";
            endereco.Cidade = "Rio de Janeiro";
            endereco.UF = "RJ";
            endereco.CEP = "23412-138";
            aluno.DefinirEndereco(endereco);

            repositorio.Adicionar(aluno);

            return aluno;
        }

        private Aluno Incluir_Aluno_Sem_Endereco_Com_Telefone()
        {
            Aluno aluno = new Aluno();

            aluno.Nome = "Thiago Ferreira";
            aluno.Data_Nascimento = DateTime.Parse("11/03/1980");

            aluno.DefinirTelefoneResidencial("21-2133-7577");
            aluno.DefinirTelefoneComercial("21-2880-3351");
            aluno.DefinirTelefoneCelular("21-7811-2633");

            repositorio.Adicionar(aluno);

            return aluno;
        }

        private Aluno Incluir_Aluno_Com_Endereco_Com_Telefone()
        {
            Aluno aluno = new Aluno();

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
            
            aluno.DefinirTelefoneResidencial("21-3977-7587");
            aluno.DefinirTelefoneCelular("21-9987-0922");

            repositorio.Adicionar(aluno);

            return aluno;
        }

        public Boolean Carga_Inicial()
        {
            Boolean erro = false;

            try
            {
                
                Incluir_Alunos();
                Incluir_Aluno_Sem_Endereco_Sem_Telefone();
                Incluir_Aluno_Com_Endereco_Sem_Telefone();
                Incluir_Aluno_Sem_Endereco_Com_Telefone();
                Incluir_Aluno_Com_Endereco_Com_Telefone();
            }
            catch
            {
                erro = true;
            }
            return !erro;
        }

        private void Incluir_Alunos()
        {
            Aluno aluno = new Aluno();
            aluno.Nome = "Joel Amoras Dias";
            aluno.Data_Nascimento = DateTime.Parse("08/12/1976");
            repositorio.Adicionar(aluno);
            /********************************************************************/
            aluno = new Aluno();
            aluno.Nome = "Paulo Silva Doria";
            aluno.Data_Nascimento = DateTime.Parse("25/03/1971");
            repositorio.Adicionar(aluno);
            /********************************************************************/
        }
        

        [Test]
        public void a_Incluir_Aluno_Sem_Endereco_Sem_Telefone()
        {
            _aluno = Incluir_Aluno_Sem_Endereco_Sem_Telefone();

            _alunoRecuperado = repositorio.ObterPorID(_aluno.ID);
            Assert.AreSame(_aluno,_alunoRecuperado);
        }

        [Test]
        public void b_Incluir_Aluno_Com_Endereco_Sem_Telefone()
        {
            _aluno = Incluir_Aluno_Com_Endereco_Sem_Telefone();
            _alunoRecuperado = repositorio.ObterPorID(_aluno.ID);
            Assert.AreSame(_aluno, _alunoRecuperado);
        }

        [Test]
        public void c_Incluir_Aluno_Sem_Endereco_Com_Telefone()
        {
            _aluno = Incluir_Aluno_Sem_Endereco_Com_Telefone();

            _alunoRecuperado = repositorio.ObterPorID(_aluno.ID);
            Assert.AreSame(_aluno, _alunoRecuperado);
        }

        [Test]
        public void d_Incluir_Aluno_Com_Endereco_Com_Telefone()
        {
            _aluno = Incluir_Aluno_Com_Endereco_Com_Telefone();
            _alunoRecuperado = repositorio.ObterPorID(_aluno.ID);
            Assert.AreSame(_aluno, _alunoRecuperado);
        }
    }
}
