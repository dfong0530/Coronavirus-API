using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiPractice.Models
{
    public partial class PercentCases
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Countries { get; set; }
        [Required]
        public int? PercentCases1 { get; set; }
    }
}
