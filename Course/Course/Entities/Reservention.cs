using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.Entities.Expeceptions;
namespace Course.Entities
{
    class Reservention
    {
        public int RoomNumber { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }

        public Reservention()
        {

        }

        public Reservention(int roomNumber, DateTime checkKin, DateTime checkOut)
        {
            if (checkOut < checkKin)
            {
                throw new DomainException("Error Chekin-in maior que Chech-out");
            }

            RoomNumber = roomNumber;
            Checkin = checkKin;
            Checkout = checkOut;
        }

        public int Duration()
        {
            TimeSpan duration = Checkout.Subtract(Checkin);
            return (int)duration.TotalDays;
        }

        public void UpdateDates(DateTime checkKin , DateTime checkOut)
        {
            DateTime now = DateTime.Now;

            if (checkKin < now || checkOut < now)
            {
                throw new DomainException("Error check-in e chech-out menor que now");

            }

            if (checkOut < checkKin)
            {
               throw new DomainException("Error Chekin-in maior que Chech-out");
            }

            Checkin = checkKin;
            Checkout = checkOut;

        }

        public override string ToString()
        {
            return "Room "
                + RoomNumber
                +", check-in: "
                + Checkin.ToString("dd/MM/yyyy")
                + ", check-out: "
                + Checkout.ToString("dd/MM/yyyy")
                +", "
                + Duration()
                +" nights";
            
        }
        
    }
}
