using GayaProject.Interfaces;

namespace GayaProject.Services
{
    public class OperatorFactoryService : IOperatorFactoryService
    {
        private readonly Dictionary<string, IOperatorService> _operatorServices;
        public OperatorFactoryService(IEnumerable<IOperatorService> services)
        {
            _operatorServices = services.ToDictionary(s => s.OperatorSymbol, s => s);
        }

        public IOperatorService? InitializeOperatorServices(string operatorChar)
        {
            return _operatorServices.TryGetValue(operatorChar, out var service) ? service : null;
        }
    }
}

