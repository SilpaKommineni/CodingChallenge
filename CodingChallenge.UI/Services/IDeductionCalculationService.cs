using CodingChallenge.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.UI.Services
{
    public interface IDeductionCalculationService
    {
        DeductionCalculationResults CalculateDeductions(Employee employee);
    }
}
