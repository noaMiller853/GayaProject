using WebApplicationUser.Models;

namespace GayaProject.Models
{
    public class CalculateRequest
    {
        public string Operation { get; set; }
        public string Argument1 { get; set; }
        public string Argument2 { get; set; }
        

    }
    public class CountIdResult
    {
        public int CountId { get; set; }
    }
}
