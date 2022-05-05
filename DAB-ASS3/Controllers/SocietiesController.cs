using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DAB_ASS3.Controllers
{
    [ApiController]
    [Route("Societies/")]
    public class SocietiesController : ControllerBase
    {
        /// <summary>
        /// Fetch all Societies.
        /// </summary>
        [HttpGet]
        public string Get()
        {
            // Samle info og sende retur...
            // Get all societies (cvr, addresses and chairmen) by their activity

            // Adgang til DB
            var db = new MyDbContext();

            // Vi laver en liste over resultaterne, og joiner Society og Chairman
            var query = (from s in db.Societies

                         join c in db.Chairmen
                         on s.chairmanid equals c.chairmanid

                         orderby s.society_activity
                         select new
                         {
                             SocietyName = s.society_name,
                             SocietyCvr = s.society_CVR,
                             ChairmanName = c.chairman_name,
                             ChairmanAddress = c.chairman_address,
                             SocietyActivity = s.society_activity
                         }).ToList();

            // Vi laver listen om til json, og returnere som string
            return JsonConvert.SerializeObject(query);
        }
    }
}
