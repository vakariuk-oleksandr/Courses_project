using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Main_Project.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Main_Project.Models;

namespace Main_Project.Data
{
    /// <summary>
    /// generic repository of the CRUD
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Basic<TEntity> : IGenrep<TEntity> where TEntity : class
    {
        private readonly AplContext _context;
        public Basic(AplContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<TEntity> Add(TEntity obj)
        {
            await _context.Set<TEntity>().AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            var res = await _context.Set<TEntity>().ToListAsync();
            return res;
        }

        public async Task<TEntity> GetById(string id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> FindAll()
        {
            return _context.Set<TEntity>()
                .AsNoTracking();
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return this._context.Set<TEntity>()
                .Where(expression)
                .AsNoTracking();
        }

        public async Task<TEntity> Delete(string id)
        {
            var obj = await _context.Set<TEntity>().FindAsync(id);
            if (obj == null)
            {
                return obj;
            }
            _context.Set<TEntity>().Remove(obj);
            return obj;
        }

        public async Task<TEntity> Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return obj;
        }
    }
}
