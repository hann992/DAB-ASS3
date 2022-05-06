using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DAB_ASS3.Models
{
    public class society
    {

        //[BsonRepresentation(BsonType.ObjectId)]

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string society_id { get; set; }
        public long society_CVR { get; set; }
        public string society_name { get; set; }
        public string society_activity { get; set; }
        public int society_member_count { get; set; }


        public chairman chairman { get; set; }

        public key_responsible keyresponsible { get; set; }
    }
}