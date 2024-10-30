using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Turbokart.DataAccess;
using Turbokart.Entities;

namespace Turbokart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController(IReservationRepository repo) : Controller
    {
        private readonly IReservationRepository _db = repo;

        [HttpPost]
        [Route("MakeReservation")]
        public IActionResult MakeReservation([FromBody] Reservation userReservation)
        {
            // Call the database and save the reservation

            if (userReservation.PeopleAttending > 0)
            {
                try
                {
                    /*
                        {
                          "id": 0,
                          "name": "Martin",
                          "email": "martin-martinili@gmail.com",
                          "phone": "+4520145632",
                          "peopleAttending": 5,
                          "currentDate": "2024-10-24T08:37:39.737Z",
                          "raceDate": "2024-10-26T08:37:39.737Z"
                        }
                     */
                    Console.WriteLine($"Du har booket en reservation den {userReservation.RaceDate.ToString(new CultureInfo("da-dk"))}\n" +
                        $"Navn: {userReservation.Name}\n" +
                        $"Email: {userReservation.Email}\n" +
                        $"Phone: {userReservation.Phone}\n" +
                        $"Attendees: {userReservation.PeopleAttending}");

                    _db.Add(userReservation);

                    return Ok(200);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("GetReservations")]
        public IEnumerable<Reservation> GetAllReservations()
        {
            return _db.GetAll();
        }
    }
}
