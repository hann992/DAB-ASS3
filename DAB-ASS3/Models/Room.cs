using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB_ASS3.Models
{
    public class room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string room_id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string location_ID { get; set; }

        public string room_name { get; set; }
        public int room_capacity { get; set; }

        List<string> room_properties { get; set; }

    }
}
