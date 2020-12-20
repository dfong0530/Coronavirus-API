using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiPractice.Models
{
    public class NumCasesPerCountryModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int? NumCases { get; set; }
        [Required]
        public string Countries { get; set; }
    }
}