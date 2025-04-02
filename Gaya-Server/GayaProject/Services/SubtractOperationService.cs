using GayaProject.Interfaces;
using WebApplicationUser.Models;

namespace GayaProject.Services
{
    public class SubtractOperatorService : IOperatorService
    {
        public string OperatorSymbol => "-";

        public string Calculate(Arguments arguments)
        {
            if (!int.TryParse(arguments.FieldOne, out int a) || !int.TryParse(arguments.FieldTwo, out int b))
            {
              return  arguments.FieldOne.Substring(0, arguments.FieldTwo.Length - 1);
            }
            return (a - b).ToString();
        }
    }
}

