using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.UI.ViewModels
{
    public class Employee : Person
    {
        [Required]
        [Range(1, 10_000_000)]
        public int YearlySalary { get; set; }
        [Required]
        [Range(1, 26)]
        public int NumberOfPaychecksPerYear { get; set; }
        public List<Dependent> Dependents { get; set; } = new List<Dependent>();
    }
}
