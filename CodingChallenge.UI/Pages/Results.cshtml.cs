using CodingChallenge.UI.Constants;
using CodingChallenge.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodingChallenge.UI.Pages
{
    public class ResultsModel : PageModel
    {

        public DeductionCalculationResults CalcuationResults { get; set; }

        public IActionResult OnGet()
        {
            CalcuationResults = TempData.Get<DeductionCalculationResults>(Constants.Constants.RESULTS_TEMP_DATA_KEY);

            if(CalcuationResults == null)
            {
                return RedirectToPage(Constants.Constants.INDEX_PAGE);
            }

            // Reset the calculation results in temp data to ensure that they are available if the user refreshes the page
            TempData.Set(Constants.Constants.RESULTS_TEMP_DATA_KEY, CalcuationResults);

            return Page();
        }
    }
}