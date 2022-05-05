﻿using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB_ASS3.Models
{
    public class location
    {
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string location_id { get; set; }
        public string location_address { get; set; }
        public int location_zipcode { get; set; }
        public string location_name { get; set; }

		location_access location_access { get; set; }

		List<string> location_properties { get; set; }

    }
}

