using Microsoft.EntityFrameworkCore;
using WebApplicationUser.Models;

namespace GayaProject.Interfaces
{
    public interface ICalculateRepository
    {
        Task<List<Operator>> GetOperations();
        Task<Operator> GetOperationByOperatorAsync(string op);
        Task<Arguments> AddArgumentsAsync(Arguments arguments);
        Task<Arguments> GetArgumentsAsync(int id);
        Task<List<Arguments>> GetArgumentsAsyncByOperationId(int idOperator);
        Task<int> GetCountExuteByMonth(int idOperator);
    }
}
