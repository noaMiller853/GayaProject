using WebApplicationUser.Models;

namespace GayaProject.Interfaces
{
    public interface IOperatorService
    {
        string OperatorSymbol { get; }   
        string Calculate(Arguments arguments);
    }
}
