using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Enumerados;
using UpperAcademy.Dominio.Servicos;

namespace UpperAcademy.Dominio.Modelo
{
    public class Professor : EntidadeBase
    {
        private ServListaFixaNivel _ServListaFixaNivel;
        private ServListaFixaStatusProfessor _ServListaFixaStatusAluno;

        public virtual String Nome { get; set; }
        public virtual DateTime? Data_Nascimento { get; set; }
        public virtual EnderecoProfessor Endereco { get; set; }
        public virtual IList<TelefoneProfessor> Telefones { get; set; }
        public virtual TelefoneProfessor TelefoneResidencial { get; set; }
        public virtual TelefoneProfessor TelefoneComercial { get; set; }
        public virtual TelefoneProfessor TelefoneCelular { get; set; }
        public virtual Int16 Nivel { get; set; }
        public virtual String Descricao_Nivel
        {
            get
            {
                return _ServListaFixaNivel.ObterPelaChave(Nivel);
            }
        }
        public virtual Int16 Status { get; set; }
        public virtual String Descricao_Status
        {
            get
            {
                return _ServListaFixaStatusAluno.ObterPelaChave(Status);
            }
        }

        public Professor()
        {
            Telefones = new List<TelefoneProfessor>();
            Nivel = 1;
            _ServListaFixaNivel = new ServListaFixaNivel();
            _ServListaFixaStatusAluno = new ServListaFixaStatusProfessor();
        }

        public virtual void CriarTelefonesPadrao()
        {
            TelefoneResidencial = new TelefoneProfessor(this, 1, "");
            TelefoneComercial = new TelefoneProfessor(this, 2, "");
            TelefoneCelular = new TelefoneProfessor(this, 3, "");
        }

        public virtual void DefinirTelefoneResidencial(String pNumero)
        {
            if (TelefoneResidencial == null)
                TelefoneResidencial = new TelefoneProfessor(this, 1, pNumero);
            else
                TelefoneResidencial.Numero = pNumero;
        }

        public virtual void DefinirTelefoneComercial(String pNumero)
        {
            if (TelefoneComercial == null)
                TelefoneComercial = new TelefoneProfessor(this, 2, pNumero);
            else
                TelefoneComercial.Numero = pNumero;
        }

        public virtual void DefinirTelefoneCelular(String pNumero)
        {
            if (TelefoneCelular == null)
                TelefoneCelular = new TelefoneProfessor(this, 3, pNumero);
            else
                TelefoneCelular.Numero = pNumero;
        }

        public virtual void DefinirEndereco(EnderecoProfessor pEndereco)
        {
            if (pEndereco.Professor != this)
                throw new Exception("Referência de professor em endereço não é válida. ");
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
