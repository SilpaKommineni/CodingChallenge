using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.UI.ViewModels
{
    public class Person
    {
        [Required]
        public string Name { get; set; }
    }
}
