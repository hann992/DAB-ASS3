using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB_ASS3.Models
{
    public class room_property
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string roomproperty_id { get; set; }
        public string room_property_name { get; set; }

        
        public List<string> room_ids { get; set; }

    }
}
