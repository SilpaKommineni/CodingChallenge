using CodingChallenge.UI.Constants;
using CodingChallenge.UI.Services;
using CodingChallenge.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace CodingChallenge.UI.Pages
{
    public class EmployeeInformationModel : PageModel
    {
        private readonly IDeductionCalculationService _deductionCalculationService;

        [BindProperty]
        public Employee Employee { get; set; }

        public List<SelectListItem> DependentTypeList { get; } = new List<SelectListItem>();

        public EmployeeInformationModel(IDeductionCalculationService deductionCalculationService)
        {
            _deductionCalculationService = deductionCalculationService;

            PopulateDependentTypeList();
        }

        #region HTTP Actions
        public IActionResult OnGet(int? numberOfDependents)
        {
            if (numberOfDependents == null)
            {
                return RedirectToPage(Constants.Constants.INDEX_PAGE);
            }

            Employee = CreateEmployeeViewModel(numberOfDependents);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Store the results in temp data so that the results page can retrieve them
            TempData.Set(Constants.Constants.RESULTS_TEMP_DATA_KEY, _deductionCalculationService.CalculateDeductions(Employee));

            return RedirectToPage(Constants.Constants.RESULTS_PAGE);
        }
        #endregion

        #region Helper Methods
        private void PopulateDependentTypeList()
        {
            foreach (var value in Enum.GetValues(typeof(DependentType)))
            {
                DependentTypeList.Add(new SelectListItem(value.ToString(), value.ToString()));
            }
        }

        private Employee CreateEmployeeViewModel(int? numberOfDependents)
        {
            var employee = new Employee();

            employee.YearlySalary = Constants.Constants.SALARY_PER_PAYCHECK * Constants.Constants.NUMBER_OF_PAYCHECKS_PER_YEAR;
            employee.NumberOfPaychecksPerYear = Constants.Constants.NUMBER_OF_PAYCHECKS_PER_YEAR;

            for (int i = 0; i < numberOfDependents; i++)
            {
                employee.Dependents.Add(new Dependent() { Type = (i == 0 ? DependentType.Spouse : DependentType.Child) });
            }

            return employee;
        }
        #endregion

    }
}