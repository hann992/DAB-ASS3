using System.ComponentModel.DataAnnotations;

namespace DAB_ASS3.Models
{
    public class key_responsible
    {
        public string key_responsible_name { get; set; }
        public long key_responsible_CPR { get; set; }
        public string key_responsible_address { get; set; }
        public long key_responsible_phone { get; set; }
        public int key_responsible_photo_id_number { get; set; }
    }
}
