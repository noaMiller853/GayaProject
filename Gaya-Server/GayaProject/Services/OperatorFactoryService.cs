using Azure;
using GayaProject.Interfaces;

namespace GayaProject.Services
{
    public class OperatorFactoryService : IOperatorFactoryService
    {
        private readonly IOperatorService _operatorService;
        public OperatorFactoryService(IOperatorService operatorService)
        {
            _operatorService = operatorService;
        }

        public IOperatorService? InitializeOperatorServices(string operatorChar)
        {
            return operatorChar switch
            {
                "+" => new AddOperatorService(),
                "-" => new SubtractOperationService(),
                "*" => new MultiplyOperationService(),
                "/" => new DivideOperationService(),
                _ => null
            };
        }
    }
    }

