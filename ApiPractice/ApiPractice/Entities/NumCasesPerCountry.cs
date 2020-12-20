using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiPractice.Models
{
    public partial class NumCasesPerCountry
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int? NumCases { get; set; }
        [Required]
        public string Countries { get; set; }
    }
}
