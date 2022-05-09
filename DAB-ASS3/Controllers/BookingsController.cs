using DAB_ASS3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoContext.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace DAB_ASS3.Controllers
{

    public class returnJson
    {
        public string RoomName { get; set; }
        public string LocationName { get; set; }
        public string SocietyName { get; set; }
        public string ChairmanName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }






    [ApiController]
    [Route("Bookings/")]
    public class BookingsController : ControllerBase
    {
        /// <summary>
        /// Fetch all bookings.
        /// </summary>
        [HttpGet]
        public string Get()
        {

            // Samle info og sende retur...
            // Get a list of booked rooms (name, location), with the booking 
            // society(name, chairmen) and the times it is booked.

            // Adgang til DB
            MongoService db = new MongoService();

            // Join søgningen
            var query = (from b in db.GetAllBookings().ToList()
                         select new
                         {
                             RoomName = b.room_name,
                             LocationName = b.location_name,
                             Society = b.society_name,
                             BookedFrom = b.booking_from,
                             BookedTo = b.booking_to
                         }).ToList();



            // Vi laver listen om til json, og returnere som string
            return JsonConvert.SerializeObject(query);
            
        }
    }
}