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
            //var db = new MyDbContext();

            //// Vi opretter en ny query, og tager bookings, og joiner: Societies, Chairmen, Rooms og Locations
            //var query = (from b in db.Bookings

            //            join s in db.Societies
            //            on b.society_Id equals s.society_ID

            //            join c in db.Chairmen
            //            on s.chairmanid equals c.chairmanid

            //            join r in db.Rooms
            //            on b.room_Id equals r.room_ID

            //            join l in db.Locations
            //            on r.location_ID equals l.location_ID

            //             // Vi laver den nye sammensluttede tabel
            //             select new
            //            {
            //                RoomName = r.room_name,
            //                LocationName = l.location_name,
            //                SocietyName = s.society_name,
            //                ChairmanName = c.chairman_name,
            //                StartTime = b.booking_from,
            //                EndTime = b.booking_to
            //            }).ToList();

            MongoService db = new MongoService();



            var query = db.Booking.Aggregate()
                        .Lookup("room", "room_id", "_id", "AsRoom")
                        .Lookup("location", "AsRoom.location_ID", "_id", "AsLocation")
                        .Lookup("society", "society_id", "_id", "AsSociety")
                        .As<BsonDocument>()
                        .ToList();


            var test = query.ConvertAll(BsonTypeMapper.MapToDotNetValue);

            string jsonNu = JsonConvert.SerializeObject(test);


            List<returnJson> returnJson = new List<returnJson>();

            foreach (var item in JsonConvert.DeserializeObject<dynamic>(jsonNu))
            {
                returnJson.Add(
                    new returnJson
                    {
                        StartTime = (DateTime)item.booking_from,
                        EndTime = (DateTime)item.booking_to,
                        RoomName = (string)item.AsRoom[0].room_name,
                        LocationName = (string)item.AsLocation[0].location_name,
                        SocietyName = (string)item.AsSociety[0].society_name,
                        ChairmanName = (string)item.AsSociety[0].chairman.chairman_name,

                    });
            }


            // Vi laver listen om til json, og returnere som string
            return JsonConvert.SerializeObject(returnJson);
            
        }
    }
}