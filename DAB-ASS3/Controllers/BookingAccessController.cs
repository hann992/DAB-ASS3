using DAB_ASS3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoContext.Services;
using MongoDB.Driver;
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
        /// <param name="keyResponsible">Key Responsible CPR</param>
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
            MongoService db = new MongoService();

            // Join søgningen
            var query = (from b in db.Booking.Find(x => x.key_responsible_CPR == keyResponsible && x.booking_from > DateTime.Now).ToList()
                            select new
                         {
                             RoomName = b.room_name,
                             LocationName = b.location_name,
                             Society = b.society_name,
                             BookedFrom = b.booking_from,
                             BookedTo = b.booking_to,
                             PickUpLocation = b.location_key_pickup_address,
                             CodeAccess = b.location_code
                         }).ToList();



            // Vi laver listen om til json, og returnere som string
            return JsonConvert.SerializeObject(query);

        }
    }
}