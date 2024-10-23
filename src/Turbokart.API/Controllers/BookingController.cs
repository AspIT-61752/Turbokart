using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Turbokart.Entities;

namespace Turbokart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : Controller
    {
        [HttpPost]
        [Route("MakeReservation")]
        public IActionResult MakeReservation([FromBody] Reservation userReservation)
        {
            // Call the database and save the reservation
            Console.WriteLine($"Du har booket en reservation den {userReservation.RaceDate.ToString(new CultureInfo("da-dk"))}\n" +
                $"Navn: {userReservation.Name}\n" +
                $"Email: {userReservation.Email}\n" +
                $"Phone: {userReservation.Phone}\n" +
                $"Attendees: {userReservation.PeopleAttending}");

            return Ok(200);
        }
    }
}
