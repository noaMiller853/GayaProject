using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationUser.Models
{
    public class Operator
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Operation { get; set; } = string.Empty;
    }
}