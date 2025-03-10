using WebApplicationUser.Models;

namespace GayaProject.Interfaces
{
    public interface ICalculateService
    {
        Task<string> CalculateArgumentsAsync(string op, Arguments arguments);
        Task<List<Operator>> GetOperationsAsync();
        Task<Arguments> AddArgumentsAsync(Arguments arguments);
        Task<List<Arguments>> GetArgumentsByOperatorId(int idOperator);
        Task<int> GetCountExuteByMonth(int idOperator);
    }
}
