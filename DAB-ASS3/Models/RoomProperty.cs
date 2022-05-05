using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB_ASS3.Models
{
    public class room_properties
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string roomproperties_id { get; set; }
        public string room_property_name { get; set; }

        List<string> room_ids { get; set; }

    }
}
