using CodingChallenge.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Service.Interfaces
{
    public interface IAnnualDeductionRate
    {
        decimal Get(PersonType personType);
    }
}
