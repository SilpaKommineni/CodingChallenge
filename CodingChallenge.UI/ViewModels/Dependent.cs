using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.UI.ViewModels
{
    public enum DependentType
    {
        Spouse,
        Child
    }

    public class Dependent : Person
    {
        [Required]
        public DependentType Type { get; set; }
    }
}
