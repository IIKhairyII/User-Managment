using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(T entity)
        {
            try
            {
                await _context.AddAsync(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex) { return -1; }
        }

        public async Task<int> DeleteAsync(T entity)
        {
            try
            {
                _context.Remove(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex) { return -1; }
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<T?> GetByConditionAsync(Expression<Func<T, bool>> condition)
        {
            try
            {
                return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(condition);
            }
            catch (Exception ex) { return null; }
        }

        public async Task<int> UpdateAsync(T entity)
        {
            try
            {
                _context.Update(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex) { return -1; }
        }
    }
}
