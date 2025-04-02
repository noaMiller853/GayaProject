using System.Diagnostics.Metrics;
using GayaProject.Interfaces;
using GayaProject.Models;
using Microsoft.EntityFrameworkCore;
using WebApplicationUser.Models;

namespace GayaProject.Repository
{
    public class CalculateRepository: ICalculateRepository
    {
        private readonly ApplicationDbContext _context;
        public CalculateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Operator>> GetOperations()
        {
            return await _context.Operation.ToListAsync();
        }
        public async Task<Operator?> GetOperationByOperatorAsync(string op)
        {
            return await _context.Operation.AsNoTracking().FirstOrDefaultAsync(o => o.Operation == op);
        }
        public async Task<Operator> AddOperationAsync(Operator operation)
        {
            _context.Operation.Add(operation);
            await _context.SaveChangesAsync();
            return operation;
        }
        public async Task<Operator> DeleteOperationByIdAsync(int id)
        {
            var operation = await _context.Operation.FindAsync(id);
            if (operation != null)
            {
                _context.Operation.Remove(operation);
                await _context.SaveChangesAsync();
            }
            return operation;
        }
        public async Task<Arguments> AddArgumentsAsync(Arguments arguments)
        {
            _context.Arguments.Add(arguments);
            await _context.SaveChangesAsync();
            return arguments;
        }
        public async Task<Arguments?> GetArgumentsAsync(int id)
        {
            return await _context.Arguments.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<List<Arguments>> GetArgumentsAsyncByOperationId(int idOperator)
        {
            return await _context.Arguments.AsNoTracking()
                .Where(a=>a.OperationId == idOperator)
                .OrderByDescending(o=>o.DateResult)
                .Take(3)
                .ToListAsync();
        }

        public async Task<int> GetCountExuteByMonth(int idOperator)
        {
            return await _context.Arguments
                .Where(o => o.OperationId == idOperator && o.DateResult.HasValue && 
                o.DateResult.Value.Month == DateTime.Now.Month)
                .CountAsync(o => o.Result != null);
        }
    }
}
