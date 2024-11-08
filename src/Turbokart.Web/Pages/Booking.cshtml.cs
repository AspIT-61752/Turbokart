using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using Turbokart.DataAccess;
using Turbokart.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Turbokart.Web.Pages
{
    public class BookingModel : PageModel
    {
        private readonly DataContext _db;

        public BookingModel(DataContext DB)
        {
            _db = DB;
        }

        // Booking properties
        public Reservation UserReservation = new();

        // Callendar properties
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

        public async Task<IActionResult> OnPostAsync()
        {
            UserReservation.Email = Request.Form["Email"];
            UserReservation.Name = Request.Form["Name"];
            UserReservation.Phone = Request.Form["PhoneNumber"];
            UserReservation.PeopleAttending = int.Parse(Request.Form["Attendees"]);

            UserReservation.CurrentDate = DateTime.Now; // I could use the CurrentDate property, but I'm using DateTime.Now so I also get the timestamp
            // UserReservation.RaceDate = DateTime.Now.AddDays(2); // I need to get the selected date from the calendar

            // Checks if the date is valid
            // TODO: Check if there's overlap with other reservations
            if (DateTime.TryParse(Request.Form["Date"], out DateTime raceDate) && raceDate > DateTime.Now)
            {
                UserReservation.RaceDate = raceDate;
            }
            else
            {
                ModelState.AddModelError("Date", "Datoen er ikke gyldig");
                return Page();
            }

            _db.Reservations.Add(UserReservation);
            await _db.SaveChangesAsync();

            // Call the database and save the reservation
            // DB.MakeReservation(UserReservation);

            // Show the user they have successfully made a reservation
            //ViewData["submit-msg"] = $"Du har booket en reservation den {UserReservation.RaceDate.ToString(new CultureInfo("da-dk"))}\n" +
            //    $"Navn: {UserReservation.Name}\n" +
            //    $"Email: {UserReservation.Email}\n" +
            //    $"Phone: {UserReservation.Phone}\n" +
            //    $"Attendees: {UserReservation.PeopleAttending}";

            TempData["submitMsg"] = $"Du har booket en reservation den {UserReservation.RaceDate.ToString(new CultureInfo("da-DK"))}\n" +
                            $"Navn: {UserReservation.Name}\n" +
                            $"Email: {UserReservation.Email}\n" +
                            $"Telefon: {UserReservation.Phone}\n" +
                            $"Antal deltagere: {UserReservation.PeopleAttending}";

            return RedirectToPage("Confirmation");
        }
    }
}
