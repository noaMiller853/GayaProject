using GayaProject.Interfaces;
using WebApplicationUser.Models;


namespace GayaProject.Services
{
    public class CalculateService : ICalculateService
    {
        private readonly ICalculateRepository _calculateRepository;
        private readonly IOperatorFactoryService _operatorFactoryService;
        private Dictionary<string, IOperatorService> _operatorServices;
        private readonly ILogger<CalculateService> _log;
        private bool _operatorsInitialized = false;

        public CalculateService( ICalculateRepository calculateRepository,IOperatorFactoryService operatorFactory,ILogger<CalculateService> log)
        {
            _calculateRepository = calculateRepository;
            _operatorFactoryService = operatorFactory;
            _operatorServices = new Dictionary<string, IOperatorService>();
            _log = log;
        }
        private async Task EnsureOperatorsInitializedAsync()
        {
            if (!_operatorsInitialized)
            {
                await InitializeOperatorsAsync();
                _operatorsInitialized = true;
            }
        }

        private async Task InitializeOperatorsAsync()
        {
            try
            {
                var operations = await _calculateRepository.GetOperations();
                foreach (var operation in operations)
                {
                    var operatorService =_operatorFactoryService.InitializeOperatorServices(operation.Operation);
                     if (operatorService != null)
                    {
                        _operatorServices[operation.Operation] = operatorService;
                    }
                }
            }
            catch (Exception ex)
            {
               _log.LogError(ex, "Failed to initialize operators");
            }
        }

        public async Task<string> CalculateArgumentsAsync(string op, Arguments arguments)
        {
            await EnsureOperatorsInitializedAsync();

            if (!_operatorServices.ContainsKey(op))
            {
                _log.LogError("Operator not found.");
                return "Operator not found.";
            }
            string result = _operatorServices[op].Calculate(arguments);
            var operation = await _calculateRepository.GetOperationByOperatorAsync(op);
            int id = operation.Id;

            Arguments arguments1 = new Arguments
            {
                FieldOne = arguments.FieldOne,
                FieldTwo = arguments.FieldTwo,
                Result = result,
                OperationId = id,
                DateResult = DateTime.Now.Date
            };
            await AddArgumentsAsync(arguments1);
            return result;
        }
       
        public async Task<List<Operator>> GetOperationsAsync()
        {
            return await _calculateRepository.GetOperations();
        }

        public async Task<Arguments> AddArgumentsAsync(Arguments arguments)
        {
            return await _calculateRepository.AddArgumentsAsync(arguments);
        }
        public async Task<List<Arguments>> GetArgumentsByOperatorId(int idOperator)
        {
            return await _calculateRepository.GetArgumentsAsyncByOperationId(idOperator);
        }

        public async Task<int> GetCountExuteByMonth(int idOperator)
        {
            return await _calculateRepository.GetCountExuteByMonth(idOperator);
        }
        
    }

    
}