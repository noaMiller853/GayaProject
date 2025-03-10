using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplicationUser.Models
{
    public class Arguments
    {
        [Key]
        public int Id { get;private set; }
        public string FieldOne { get; set; }
        public string FieldTwo { get; set; }
        public string? Result { get; set; }
        public int? OperationId { get; set; }
        public DateTime? DateResult { get; set; }


    }
}