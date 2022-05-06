using Microsoft.AspNetCore.Mvc;
using MongoContext.Services;
using Newtonsoft.Json;
using DAB_ASS3.Models;

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
            //var db = new MyDbContext();

            //// Vi laver en liste over resultaterne, og joiner Society og Chairman
            //var query = (from s in db.Societies

            //             join c in db.Chairmen
            //             on s.chairmanid equals c.chairmanid

            //             orderby s.society_activity
            //             select new
            //             {
            //                 SocietyName = s.society_name,
            //                 SocietyCvr = s.society_CVR,
            //                 ChairmanName = c.chairman_name,
            //                 ChairmanAddress = c.chairman_address,
            //                 SocietyActivity = s.society_activity
            //             }).ToList();

            // Vi laver listen om til json, og returnere som string

            MongoService db = new MongoService();

            var societies = db.GetAllSocieties();

            societies.Sort(delegate (society x, society y)
            {
                if (x.society_activity == null && y.society_activity == null) return 0;
                else if (x.society_activity == null) return -1;
                else if (y.society_activity == null) return 1;
                else return x.society_activity.CompareTo(y.society_activity);
            });

            var endelige = (from s in societies
                         select new
                         {
                             SocietyName = s.society_name,
                             SocietyCvr = s.society_CVR,
                             ChairmanName = s.chairman.chairman_name,
                             ChairmanAddress = s.chairman.chairman_address,
                             SocietyActivity = s.society_activity,
                         }).ToList();

            return JsonConvert.SerializeObject(endelige);
        }
    }
}
