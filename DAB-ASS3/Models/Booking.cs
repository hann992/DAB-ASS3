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


        // Til at hente data til BookingsControlleren

        public string room_name { get; set; }

        public string location_name { get; set; }

        public string society_name { get; set; }

        public string chairman_name { get; set; }


        // Til at hente date til BookingAccessControlleren

        public long key_responsible_CPR { get; set; }

        public string location_key_pickup_address { get; set; } = null;

        public int location_code { get; set; }


    }
}
