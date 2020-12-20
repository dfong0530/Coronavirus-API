using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiPractice.Models
{
    public class GlobalCasesModels
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Month { get; set; }
        [Required]
        public int? NumberOfCases { get; set; }
    }
}