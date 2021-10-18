using DesafioDeCasa.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioDeCasa.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DesafioDeCasaContext _context;

        public Repository([FromServices] DesafioDeCasaContext context)
        {
            _context = context;
        }

        public TEntity Get(long id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public TEntity Adicionar(TEntity entity)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception e)
            {
                // TODO: Gerenciar excessões   
            }
            return entity;
        }

        public TEntity Atualizar(TEntity entity)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                _context.Set<TEntity>().Update(entity);
                _context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception e)
            {
                // TODO: Gerenciar excessões   
            }
            return entity;
        }

        public void AdicionarVarios(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            _context.SaveChanges();
        }
        public void Remover(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
        public void RemoverVarios(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            _context.SaveChanges();
        }
    }
}
