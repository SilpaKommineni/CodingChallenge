using CodingChallenge.Domain.Constants;
using CodingChallenge.Service.Interfaces;
using CodingChallenge.UI.Constants;
using CodingChallenge.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.UI.Services
{
    public class DeductionCalculationService : IDeductionCalculationService
    {
        private readonly IDeductionCalculator _deductionCalculator;

        public DeductionCalculationService(IDeductionCalculator deductionCalculator)
        {
            _deductionCalculator = deductionCalculator;
        }

        public DeductionCalculationResults CalculateDeductions(Employee employee)
        {
            List<Domain.Person> persons = Converters.ConvertEmployeeToPersonList(employee);
            decimal employeeDedudctionPerPayCheck = _deductionCalculator.CalculateDeductionPerPaycheck(persons.Where(p => p.Type == PersonType.Employee).ToList(), employee.NumberOfPaychecksPerYear);
            decimal dependentsDeductionPerPayCheck = _deductionCalculator.CalculateDeductionPerPaycheck(persons.Where(p => p.Type != PersonType.Employee).ToList(), employee.NumberOfPaychecksPerYear);
            decimal totalDeductionPerPayCheck = _deductionCalculator.CalculateDeductionPerPaycheck(persons, employee.NumberOfPaychecksPerYear);
            decimal employeeDeductionPerYear = _deductionCalculator.CalculateDeductionPerAnnum(persons.Where(p => p.Type == PersonType.Employee).ToList());
            decimal dependentDeductionPerYear = _deductionCalculator.CalculateDeductionPerAnnum(persons.Where(p => p.Type != PersonType.Employee).ToList());
            decimal totalDeductionPerYear = _deductionCalculator.CalculateDeductionPerAnnum(persons);
            decimal employeePaycheckAfterDeductions = (employee.YearlySalary / (decimal)employee.NumberOfPaychecksPerYear) - totalDeductionPerPayCheck;
            decimal employeeYearlyPayAfterDeductions = employee.YearlySalary - totalDeductionPerYear;

            return new DeductionCalculationResults()
            {
                EmployeeDeductionPerPayCheck = employeeDedudctionPerPayCheck,
                DependentsDeductionPerPayCheck = dependentsDeductionPerPayCheck,
                TotalDeductionPerPayCheck = totalDeductionPerPayCheck,
                EmployeeDeductionPerYear = employeeDeductionPerYear,
                DependentsDeductionPerYear = dependentDeductionPerYear,
                TotalDeductionPerYear = totalDeductionPerYear,
                EmployeePaycheckAfterDeductions = employeePaycheckAfterDeductions,
                EmployeeYearlyPayAfterDeductions = employeeYearlyPayAfterDeductions
            };
        }
    }
}
