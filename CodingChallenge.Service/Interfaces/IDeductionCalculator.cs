using CodingChallenge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Service.Interfaces
{
    public interface IDeductionCalculator
    {
        decimal CalculateDeductionPerPaycheck(List<Person> persons, int numberOfPaychecksPerYear);
        decimal CalculateDeductionPerAnnum(List<Person> persons);
        decimal CalculateDeductionWithDiscount(Person person);
    }
}
