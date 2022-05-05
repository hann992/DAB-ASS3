using System;
using System.Collections.Generic;
using System.ComponentModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB_ASS3.Models
{
    public class booking
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BookingID { get; set; }

        public DateTime booking_from { get; set; }

        public DateTime booking_to { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string society_id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string room_id { get; set; }

    }
}
