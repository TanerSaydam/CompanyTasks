using Application.Services;
using DataAccess.Context;
using Entity.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly eCommerceDbContext _context;

        public Repository(eCommerceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> models)
        {
            await Table.AddRangeAsync(models);
            return true;
        }

        public bool Delete(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool DeleteRange(List<T> models)
        {
            Table.RemoveRange(models);
            return true;
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> list = Table.AsQueryable();
            return list;
        }

        public async Task<T> GetById(string id)
        {
            T model = await Table.FindAsync(id);
            return model;
        }

        public async Task<T> GetSingle(Expression<Func<T, bool>> predicate)
        {
            T model = await Table.SingleOrDefaultAsync(predicate);
            return model;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> list = Table.Where(predicate);
            return list;
        }

        public bool Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
        {
            int count = await _context.SaveChangesAsync();
            return count;
        }
    }
}
