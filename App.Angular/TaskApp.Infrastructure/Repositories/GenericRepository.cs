using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.Interfaces;
using TaskApp.Infrastructure.Data;

namespace TaskApp.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            var result = _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);

            result = result ?? throw new Exception("Entity not found");

            return result;
        }

        public async Task<List<T>> ListAsync()
        {
            var result = await _context.Set<T>().ToListAsync();

            return result;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
