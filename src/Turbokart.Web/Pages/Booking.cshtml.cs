using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Turbokart.Web.Pages
{
    public class BookingModel : PageModel
    {
        public DateTime CurrentDate { get; set; }
        public DateTime FirstDayOfMonth { get; set; }
        public int DaysInMonth { get; set; }

        public void OnGet(int? year, int? month)
        {
            if (year.HasValue && month.HasValue)
            {
                CurrentDate = new DateTime(year.Value, month.Value, 1);
            }
            else
            {
                CurrentDate = DateTime.Now;
            }

            FirstDayOfMonth = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
            DaysInMonth = DateTime.DaysInMonth(CurrentDate.Year, CurrentDate.Month);
        }
    }
}
