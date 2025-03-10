using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplicationUser.Models
{
    public class Operator
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(1)")]
        public string Operation { get; set; } = string.Empty;
    }
}