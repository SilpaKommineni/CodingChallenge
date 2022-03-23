using CodingChallenge.Domain.Constants;
using CodingChallenge.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Service
{
    public class AnnualDeductionRate : IAnnualDeductionRate
    {
        public decimal Get(PersonType personType)
        {
            switch (personType)
            {
                case PersonType.Employee:
                    return Constants.Constants.EMPLOYEE_DEDUCTION_PER_YEAR;
                case PersonType.Spouse:
                case PersonType.Child:
                    return Constants.Constants.DEPENDENT_DEDUCTION_PER_YEAR;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
