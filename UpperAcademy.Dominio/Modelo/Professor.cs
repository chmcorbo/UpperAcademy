using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpperAcademy.Dominio.Modelo
{
    public class Professor : EntidadeBase
    {
        public virtual String Nome { get; set; }
        public virtual DateTime Data_Nascimento { get; set; }
        public virtual Int32 Nivel { get; set; }
        public virtual EnderecoProfessor Endereco { get; set; }
        public virtual IList<TelefoneProfessor> Telefones { get; set; }

        public Professor()
        {
            Telefones = new List<TelefoneProfessor>();
        }

        private TelefoneProfessor ExisteTelefone(Int32 pTipoTelefone, String pNumero)
        {
            return Telefones.Where(t => t.TipoTelefone == pTipoTelefone && t.Numero == pNumero).FirstOrDefault();
        }


        public virtual void AdicionarTelefone(Int16 pTipoTelefone, String pNumero)
        {
            if (ExisteTelefone(pTipoTelefone, pNumero) != null)
                throw new Exception("Telefone já adicionado para o aluno");
            else
            {
                TelefoneProfessor telefone = new TelefoneProfessor(this, pTipoTelefone, pNumero);
                Telefones.Add(telefone);
            }
        }

        public virtual void RemoverTelefone(Int32 pTipoTelefone, String pNumero)
        {
            TelefoneProfessor telefone = ExisteTelefone(pTipoTelefone, pNumero);
            if (telefone != null)
                Telefones.Remove(telefone);
        }

        public virtual void DefinirEndereco(EnderecoProfessor pEndereco)
        {
            if (pEndereco.Professor != this)
                throw new Exception("Referência de aluno em endereço não é válida. ");
            Endereco = pEndereco;
        }

        public virtual void RemoverEndereco()
        {
            Endereco = null;
        }

    }
}
