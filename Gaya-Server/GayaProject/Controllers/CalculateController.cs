using GayaProject.Interfaces;
using GayaProject.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplicationUser.Models;

namespace GayaProject.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculateController : ControllerBase
{
    private readonly ILogger<CalculateController> _logger;
    private readonly ICalculateService _calculateService;

    public CalculateController(ILogger<CalculateController> logger,ICalculateService calculateService)
    {
        _logger = logger;
        _calculateService = calculateService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Operator>>> GetOperations()
    {
        var operations = await _calculateService.GetOperationsAsync();
        if (operations == null)
            return NotFound($"Operators  not found.");
        return Ok(operations);
    }

    [HttpPost("Arguments")]
       
    public async Task<ActionResult<IEnumerable<Arguments>>> GetArguments([FromBody]OperatorRequest request)
    {
        var arguments = await _calculateService.GetArgumentsByOperatorId(request.IdOperator);
        if (arguments == null)
            return NotFound($"Arguments not found.");
        return Ok(arguments);
    }

    [HttpPost]
    public async Task<ActionResult<string>> CalculateArguments([FromBody] CalculateRequest request)
    {
        Arguments arguments = new Arguments { FieldOne = request.Argument1, FieldTwo = request.Argument2 };
        var result = await _calculateService.CalculateArgumentsAsync(request.Operation, arguments);
        if (result == null) 
        {
            _logger.LogInformation($"Operation not found.");
            return NotFound("Operation not found."); 
        }
        return Ok(result);
    }
  
}
