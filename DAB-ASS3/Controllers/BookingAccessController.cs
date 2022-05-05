using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DAB_ASS3.Controllers
{
    [ApiController]
    [Route("BookingAccess/")]
    public class BookingAccessController : ControllerBase
    {
        /// <summary>
        /// Fetch a list of all future bookings with acces info.
        /// </summary>
        /// <param name="keyResponsible">Key Responsible ID</param>
        /// <returns></returns>
        [HttpGet("{keyResponsible}")]   // Vi tager en long int ind som key
        public string Get(long keyResponsible)
        {

            /*
            Given a key-responsible the municipalities would like to offer a 
            service, where the key-responsible can print a list of all future 
            bookings, with access information.
            */

            // Adgang til DB
            // var db = new MyDbContext();

            // Vi opretter en ny query, og tager Bookings, og joiner: Societies, keyResponsibles, Rooms, Locations, LocationAccesses.
            // Vi har også constraints: keyResponsible skal være den søgte key, OG vi vil kun se bookings, som slutter i fremtiden

            //var query = (from b in db.Bookings

            //             join s in db.Societies
            //             on b.society_Id equals s.society_ID

            //             join k in db.keyResponsibles
            //             on s.KeyResponsible_Id equals k.key_responsible_ID

            //             join r in db.Rooms
            //             on b.room_Id equals r.room_ID

            //             join l in db.Locations
            //             on r.location_ID equals l.location_ID

            //             join la in db.LocationAccesses
            //             on l.location_ID equals la.locationId

            //             where k.key_responsible_ID == keyResponsible

            //             where b.booking_to > DateTime.Now

            //             select new
            //             {
            //                 RoomName = r.room_name,
            //                 LocationName = l.location_name,
            //                 BookingFrom = b.booking_from,
            //                 BookingTo = b.booking_to,
            //                 AccessKeyPickUp = la.location_key_pickup_address,
            //                 AccessCode = la.locationcode

            //             }).ToList();

            // Vi laver listen om til json, og returnere som string
            return JsonConvert.SerializeObject("temp");

        }
    }
}