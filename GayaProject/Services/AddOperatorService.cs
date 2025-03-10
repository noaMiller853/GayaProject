using GayaProject.Interfaces;
using WebApplicationUser.Models;

namespace GayaProject.Services
{
    public class AddOperatorService : IOperatorService
    {
        public AddOperatorService()
        {
        }
        public string Calculate(Arguments arguments)
        {
            if (!int.TryParse(arguments.FieldOne, out int a) || !int.TryParse(arguments.FieldTwo, out int b))
            {
                return string.Concat(arguments.FieldOne, arguments.FieldTwo);
            }
            return (a + b).ToString();
        }

    }
}
