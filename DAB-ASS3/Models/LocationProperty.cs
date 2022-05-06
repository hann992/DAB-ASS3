using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB_ASS3.Models
{
    public class location_property
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string location_property_id { get; set; }
        public string location_property_name { get; set; }

        
        public List<string> location_ids { get; set; }


    }
}
