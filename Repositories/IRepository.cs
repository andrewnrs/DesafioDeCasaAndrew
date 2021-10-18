using DesafioDeCasa.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioDeCasa.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(long id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity Adicionar(TEntity entity);
        void AdicionarVarios(IEnumerable<TEntity> entities);

        void Remover(TEntity entity);
        void RemoverVarios(IEnumerable<TEntity> entities);

    }
}
