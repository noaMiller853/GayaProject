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
        public async Task<Operator> GetOperationByOperatorAsync(string op)
        {
            return await _context.Operation.FirstOrDefaultAsync(o => o.Operation == op);
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
        public async Task<Arguments> GetArgumentsAsync(int id)
        {
            return await _context.Arguments.FindAsync(id);
        }
        public async Task<List<Arguments>> GetArgumentsAsyncByOperationId(int idOperator)
        {
            return await _context.Arguments
                .FromSqlRaw("EXEC SelectResultTop3ByOperator @Id = {0}", idOperator)
                .ToListAsync();
        }

        public async Task<int> GetCountExuteByMonth(int idOperator)
        {
            var result = await _context.Set<CountIdResult>()
                .FromSqlRaw("EXEC SelectCountExcuteByDate @Id = {0}", idOperator)
                .FirstOrDefaultAsync();

            return result?.CountId ?? 0;
        }
    }
}
