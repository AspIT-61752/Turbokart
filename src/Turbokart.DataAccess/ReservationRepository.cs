using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbokart.Entities;

namespace Turbokart.DataAccess
{
    public class ReservationRepository(DataContext context) : Repository<Reservation>(context), IReservationRepository
    {
        public IEnumerable<Reservation> GetReservationsForDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetReservationsForMonth(DateTime month)
        {
            throw new NotImplementedException();
        }
    }

    public interface IReservationRepository : IRepository<Reservation>
    {
        IEnumerable<Reservation> GetReservationsForDate(DateTime date);
        IEnumerable<Reservation> GetReservationsForMonth(DateTime month);
    }
}
