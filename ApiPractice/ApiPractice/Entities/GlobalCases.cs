using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiPractice.Models
{
    public partial class GlobalCases
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        public string Month { get; set; }
        [Required]
        public int? NumberOfCases { get; set; }
    }
}
