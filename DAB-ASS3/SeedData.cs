using DAB_ASS3.Models;
using Microsoft.EntityFrameworkCore;
using MongoContext.Services;

namespace DAB_ASS3  // SKAL OPDATERES
{
    public class SeedData
    {
        public static void SeedDatabase()
        {

            MongoService db = new MongoService();


            Console.WriteLine("Making new society");

            society newSociety = new society();

            newSociety.society_name = "Hoppeklub";
            newSociety.society_activity = "Hvad tror du selv!";
            newSociety.society_CVR = 123456789;
            newSociety.society_member_count = 10000;

            chairman ChairMan = new chairman();

            ChairMan.chairman_name = "Hugo";
            ChairMan.chairman_address = "432 et sted";
            ChairMan.chairman_CPR = 12364654;
            

            key_responsible keyDude = new key_responsible();

            keyDude.key_responsible_address = "123 et sted";
            keyDude.key_responsible_name = "Vigtig dude";
            keyDude.key_responsible_phone = 123456789;
            keyDude.key_responsible_CPR = 12345678;


            newSociety.chairman = ChairMan;

            newSociety.keyresponsible = keyDude;

            db.CreateSociety(newSociety);

            Console.WriteLine("Done!");

        }
    }
}
