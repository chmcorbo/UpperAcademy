using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Enumerados;
using UpperAcademy.Dominio.Servicos;

namespace UpperAcademy.Dominio.Modelo
{
    public class Aluno : EntidadeBase
    {
        private ServListaFixaStatusAluno _ServListaFixaStatusAluno;

        public virtual String Matricula { get; set; }
        public virtual String Nome { get; set; }
        public virtual DateTime? Data_Nascimento { get; set; }
        public virtual EnderecoAluno Endereco { get; set; }
        public virtual TelefoneAluno TelefoneResidencial { get; set; }
        public virtual TelefoneAluno TelefoneComercial { get; set; }
        public virtual TelefoneAluno TelefoneCelular { get; set; }
        public virtual Int16 Status { get; set; }
        public virtual String Descricao_Status
        {
            get
            {
                return _ServListaFixaStatusAluno.ObterPelaChave(Status);
            }
        }


        public virtual void StatusCadastrado()
        {
            Status = 1;
        }

        public virtual void StatusMatriculado()
        {
            Status = 2;
        }

        public Aluno()
        {
            StatusCadastrado();
            _ServListaFixaStatusAluno = new ServListaFixaStatusAluno();
        }

        public virtual void CriarTelefonesPadrao()
        {
            TelefoneResidencial = new TelefoneAluno(this, 1, "");
            TelefoneComercial = new TelefoneAluno(this, 2, "");
            TelefoneCelular = new TelefoneAluno(this, 3, "");
        }

        public virtual void DefinirTelefoneResidencial(String pNumero)
        {
            if (TelefoneResidencial == null)
                TelefoneResidencial = new TelefoneAluno(this, 1, pNumero);
            else
                TelefoneResidencial.Numero = pNumero;
        }

        public virtual void DefinirTelefoneComercial(String pNumero)
        {
            if (TelefoneComercial == null)
                TelefoneComercial = new TelefoneAluno(this, 2, pNumero);
            else
                TelefoneComercial.Numero = pNumero;
        }

        public virtual void DefinirTelefoneCelular(String pNumero)
        {
            if (TelefoneCelular == null)
                TelefoneCelular = new TelefoneAluno(this,3,pNumero);
            else
                TelefoneCelular.Numero = pNumero;
        }

        public virtual void DefinirEndereco(EnderecoAluno pEndereco)
        {
            if (pEndereco.Aluno == null || pEndereco.Aluno != this)
                throw new Exception("Referência de aluno em endereço não é válida. ");
            Endereco = pEndereco;
        }

        public virtual void RemoverEndereco()
        {
            Endereco = null;
        }

        public virtual void SetStatusCadastrado()
        {
            Status = 1;
        }

        public virtual void SetStatusAlocado()
        {
            Status = 2;
        }
    }
}
