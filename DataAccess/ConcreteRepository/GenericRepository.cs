using DataAccess.AbstractRepository;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConcreteRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseClass
    {
        private readonly OrderAndManagmentDbContext _context;
        private readonly DbSet<T> _entities;

        public GenericRepository(OrderAndManagmentDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var GetId = await GetByIdAsync(id);
            _entities.Remove(GetId);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Id.ToString() == id.ToString());
        }

        public async Task UpdateAsync(T entity, string id)
        {
            var existingEntity = await GetByIdAsync(id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                entity.CreatedTime = DateTime.Now;
                _entities.Update(existingEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
