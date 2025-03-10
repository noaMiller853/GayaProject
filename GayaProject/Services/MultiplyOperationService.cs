using GayaProject.Interfaces;
using WebApplicationUser.Models;

namespace GayaProject.Services
{
    public class MultiplyOperationService : IOperatorService
    {
        public string Calculate(Arguments arguments)
        {
            if (!int.TryParse(arguments.FieldOne, out int a) || !int.TryParse(arguments.FieldTwo, out int b))
            {
                return "Do not perform this operation on a string.";
            }
            return (a * b).ToString();
        }
    }
}
