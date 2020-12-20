using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiPractice.Models
{
    public class PercentCasesModels
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Countries { get; set; }
        [Required]
        public int? PercentCases1 { get; set; }
    }
}