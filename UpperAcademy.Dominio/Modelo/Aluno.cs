using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Enumerados;

namespace UpperAcademy.Dominio.Modelo
{
    public class Aluno : EntidadeBase
    {
        public virtual String Nome { get; set; }
        public virtual DateTime? Data_Nascimento { get; set; }
        public virtual EnderecoAluno Endereco { get; set; }
        public virtual IList<TelefoneAluno> Telefones { get; set; }
        public virtual StatusAluno Status { get; set; }

        public virtual void StatusCadastrado()
        {
            Status = StatusAluno.Cadastrado;
        }

        public virtual void StatusMatriculado()
        {
            Status = StatusAluno.Matriculado;
        }

        public Aluno()
        {
            Telefones = new List<TelefoneAluno>();
            StatusCadastrado();
        }

        private TelefoneAluno ExisteTelefone(Int32 pTipoTelefone, String pNumero)
        {
            return Telefones.Where(t => t.TipoTelefone == pTipoTelefone && t.Numero == pNumero).FirstOrDefault();
        }


        public virtual void AdicionarTelefone(Int16 pTipoTelefone, String pNumero)
        {
            if (ExisteTelefone(pTipoTelefone,pNumero) !=null)
                throw new Exception("Telefone já adicionado para o aluno");
            else
            {
                TelefoneAluno telefone = new TelefoneAluno(this,pTipoTelefone,pNumero);
                Telefones.Add(telefone);
            }
        }

        public virtual void RemoverTelefone(Int32 pTipoTelefone, String pNumero)
        {
            TelefoneAluno telefone = ExisteTelefone(pTipoTelefone, pNumero);
            if (telefone!=null)
                Telefones.Remove(telefone);
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
    }
}
