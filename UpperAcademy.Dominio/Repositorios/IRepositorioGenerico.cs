using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpperAcademy.Dominio.Modelo;

namespace UpperAcademy.Dominio.Repositorios
{
    public interface IRepositorioGenerico<T> where T:EntidadeBase
    {
        void Adicionar(T pEntidadeBase);
        void Excluir(T pEntidadeBase);
        void Atualizar(T pEntidadeBase);
        IQueryable<T> ListarTudo();
    }
}
