using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DAB_ASS3.Controllers
{
    [ApiController]
    [Route("MunicipalityInfo/")]
    public class MunicipalityInfoController : ControllerBase
    {
        /// <summary>
        /// Fetch all Municipality Rooms and their Locations.
        /// </summary>
        [HttpGet]
        public string Get()
        {
            // Samle info og sende retur...
            // Get all municipality information: rooms (addresses)

            // Adgang til DB
            var db = new MyDbContext();

            // Vi laver en liste over resultaterne, hvor vi tager Rooms, og joiner locations
            var query = (from r in db.Rooms

                         join l in db.Locations
                         on r.location_ID equals l.location_ID

                         // Vi laver den nye sammensluttede tabel
                         select new
                         {
                             RoomName = r.room_name,
                             RoomCapacity = r.room_capacity,
                             LocationName = l.location_name,
                             Address = l.location_address,
                             ZipCode = l.location_zipcode
                         }).ToList();

            // Vi laver listen om til json, og returnere som string
            return JsonConvert.SerializeObject(query);
        }
    }
}
