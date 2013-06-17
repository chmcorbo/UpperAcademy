using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Enumerados;

namespace UpperAcademy.Dominio.Modelo
{
    public class Professor : EntidadeBase
    {
        public virtual String Nome { get; set; }
        public virtual DateTime Data_Nascimento { get; set; }
        public virtual cNivel Nivel { get; set; }
        public virtual EnderecoProfessor Endereco { get; set; }
        public virtual IList<TelefoneProfessor> Telefones { get; set; }
        public virtual TelefoneProfessor TelefoneResidencial { get; set; }
        public virtual TelefoneProfessor TelefoneComercial { get; set; }
        public virtual TelefoneProfessor TelefoneCelular { get; set; }
        public virtual StatusProfessor Status {get; set;}


        public Professor()
        {
            Telefones = new List<TelefoneProfessor>();
            Nivel = cNivel.Basico;
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

    }
}
