using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB_ASS3.Models
{
    public class location_access
    {
        public int location_access_code { get; set; }
        public string location_key_pickup_address { get; set; } = null;

    }
}

