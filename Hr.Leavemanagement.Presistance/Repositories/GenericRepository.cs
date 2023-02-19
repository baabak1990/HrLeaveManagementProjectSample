using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hr.Leavemanagement.Presistance.Context;
using Microsoft.EntityFrameworkCore.Design.Internal;
using HrLeaveManagement.Application.Contracts.Presistence.Repositories;
using HrLeaveManagement.Application.Features.LeaveTypes.Request.Querries;
using Microsoft.EntityFrameworkCore;

namespace Hr.Leavemanagement.Presistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
    where T : class
    {
        private readonly LeaveManagementContext _context;

        public GenericRepository(LeaveManagementContext context)
        {
            this._context = context;
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> IsExistById(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity != null;
        }

        public async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
