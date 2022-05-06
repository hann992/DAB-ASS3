using DAB_ASS3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MongoContext.Services;

namespace DAB_ASS3  // SKAL OPDATERES
{
public class SeedData
{
    static Random rnd = new Random();


    // Data til at fylde i Societies, Locations osv...

    // En masse adresser
    static List<string> adresser = new List<string>()
    {
        "Tulipanlunden,47C,1,tv,8200,Aarhus",
        "Dirch Passers Gade,30,st,th,8000,Aarhus C",
        "John Mogensens Gade,1,3,3,8000,Aarhus C",
        "Thomas Koppels Gade,20,3,tv,8000,Aarhus C",
        "Abildgade,8,1,8200,Aarhus N",
        "Dan Turells Gade,20,3,3,8000,Aarhus C",
        "Abildhaven,2,st,tv,8520,Lystrup",
        "Absalonsgade,31B,2,8000,Aarhus C",
        "Baldersgade,39,2,tv,8230,Åbyhøj",
        "Sifsgade,29,2,th,8230,Åbyhøj",
        "Acervej,23,8462,Harlev J",
        "Vistihøjen,93,1,th,Lisbjerg,8200,Aarhus N",
    };

    // Find tilfældigt adresse
    static string adresse { get => adresser[rnd.Next(adresser.Count())]; }

    // En masse fornavne
    static List<string> fornavne = new List<string>()
    {
        "Torben",
        "Michael",
        "Thomas",
        "Mads",
        "Peter",
        "Thorkil",
        "Hugo",
        "Anne",
        "Pia",
        "Meiken",
        "Kirstine",
        "Maja",
        "Britta",
        "Solvej",
    };

    // Find tilfældigt fornavn
    static string fornavn { get => fornavne[rnd.Next(fornavne.Count())]; }

    // En masse efternavne
    static  List<string> efternavne = new List<string>()
    {
        "Jacobsen",
        "Sørensen",
        "Nielsen",
        "Jensen",
        "Hansen",
        "Pedersen",
        "Andersen",
        "Christensen",
        "Larsen",
        "Rasmussen",
        "Jørgensen",
    };

    // Find tilfældigt efternavn
    static string efternavn { get => efternavne[rnd.Next(efternavne.Count())]; }

    // Find et tilfældigt fornavn & efternavn
    static string navn { get => fornavn + " " + efternavn; }

    static List<string> rumnavne = new List<string>()
    {
        "B2",
        "A3",
        "1.5",
        "1.1",
        "1.9",
        "Alfreds kontor",
        "Mødelokale 5b",
        "Kosteskab",
        "Cafe",
        "Køkkenet"
    };

    static string rumnavn { get => rumnavne[rnd.Next(rumnavne.Count())]; }

    static List<string> rumpropnavne = new List<string>()
    {
        "Køleskab",
        "Ekstra stole",
        "Tavle",
        "Projektor",
        "Bålplads",
        "Dør til narnia",
    };

    static string rumprop { get => rumpropnavne[rnd.Next(rumpropnavne.Count())]; }


    static List<string> lokationpropnavne = new List<string>()
    {
        "Svømmehal",
        "Fodboldbane",
        "Toiletter",
        "Hopperum",
        "Springvand",
        "Spawn of Cthulhu",
    };

    static string lokationprop { get => lokationpropnavne[rnd.Next(lokationpropnavne.Count())]; }


    public static void SeedDatabase()
    {

        // Oprettelse af MongoDB objekt
        MongoService db = new MongoService();

        Console.WriteLine("Dropping all collections!");
        db.DropAllCollections();

        Console.WriteLine("Making new Societies");

        // Liste over alle societies
        List<society> newSocieties = new List<society>()
        {   
            new society(){
                society_name = "Hoppeklubben",
                society_activity = "Hvad tror du selv!",
                society_CVR = rnd.Next(10000000, 99999999),
                society_member_count = rnd.Next(1, 120),
                chairman = new chairman()
                {
                    chairman_name = navn,
                    chairman_address = adresse,
                    chairman_CPR = rnd.Next(10000000, 99999999),
                },
                keyresponsible = new key_responsible()
                {
                    key_responsible_address = adresse,
                    key_responsible_name = navn,
                    key_responsible_phone = rnd.Next(10000000, 99999999),
                    key_responsible_CPR = rnd.Next(10000000, 99999999),
                }
            },
            new society(){
                society_name = "Senior Dans",
                society_activity = "Dans",
                society_CVR = rnd.Next(10000000, 99999999),
                society_member_count = rnd.Next(1, 120),
                chairman = new chairman()
                {
                    chairman_name = navn,
                    chairman_address = adresse,
                    chairman_CPR = rnd.Next(10000000, 99999999),
                },
                keyresponsible = new key_responsible()
                {
                    key_responsible_address = adresse,
                    key_responsible_name = navn,
                    key_responsible_phone = rnd.Next(10000000, 99999999),
                    key_responsible_CPR = rnd.Next(10000000, 99999999),
                }
            },
            new society(){
                society_name = "Meditationsforeningen",
                society_activity = "Meditation",
                society_CVR = rnd.Next(10000000, 99999999),
                society_member_count = rnd.Next(1, 120),
                chairman = new chairman()
                {
                    chairman_name = navn,
                    chairman_address = adresse,
                    chairman_CPR = rnd.Next(10000000, 99999999),
                },
                keyresponsible = new key_responsible()
                {
                    key_responsible_address = adresse,
                    key_responsible_name = navn,
                    key_responsible_phone = rnd.Next(10000000, 99999999),
                    key_responsible_CPR = rnd.Next(10000000, 99999999),
                }
            },
            new society(){
                society_name = "Royal Bastards Society",
                society_activity = "Being royal asses",
                society_CVR = rnd.Next(10000000, 99999999),
                society_member_count = rnd.Next(1, 120),
                chairman = new chairman()
                {
                    chairman_name = navn,
                    chairman_address = adresse,
                    chairman_CPR = rnd.Next(10000000, 99999999),
                },
                keyresponsible = new key_responsible()
                {
                    key_responsible_address = adresse,
                    key_responsible_name = navn,
                    key_responsible_phone = rnd.Next(10000000, 99999999),
                    key_responsible_CPR = rnd.Next(10000000, 99999999),
                }
            },
             new society(){
                society_name = "Bingo Bango",
                society_activity = "Bingo",
                society_CVR = rnd.Next(10000000, 99999999),
                society_member_count = rnd.Next(1, 120),
                chairman = new chairman()
                {
                    chairman_name = navn,
                    chairman_address = adresse,
                    chairman_CPR = rnd.Next(10000000, 99999999),
                },
                keyresponsible = new key_responsible()
                {
                    key_responsible_address = adresse,
                    key_responsible_name = navn,
                    key_responsible_phone = rnd.Next(10000000, 99999999),
                    key_responsible_CPR = rnd.Next(10000000, 99999999),
                }
            },
        };

        // Alle Societies fra listen skabes i DB:
        foreach (var society in newSocieties.ToList())
        {
            db.CreateSociety(society);
        }



        // Lav 10 locations:
        Console.WriteLine("Making new Locations");
        for (int i = 0; i < 10; i++)
        {
            db.CreateLocation(new location()
            {
                location_name = adresse.Split(",")[0] + fornavn + "s skole",
                location_zipcode = rnd.Next(1000, 9999),
                location_address = adresse,
                location_access = new List<location_access>()
                {
                    new location_access()
                    {
                        location_access_code = rnd.Next(1000, 9999),
                        location_key_pickup_address = adresse
                    }
                },
                location_properties = new List<location_property>()
                {
                    new location_property()
                    {
                        location_property_name = lokationprop
                    }
                }
            });
        }


        // Giver lokationer rum og props, og rummene props
        Console.WriteLine("Making new Rooms at Locations and adding Properties");
        foreach (var location in db.GetAllLocations().ToList())
        {
            // Alle lokationer får mellem 2 - 6 rum
            for (int i = 0; i < rnd.Next(2, 6); i++)
            {
                db.CreateRoom(new room()
                {
                    room_name = rumnavn,
                    room_capacity = rnd.Next(10, 100),
                    location_ID = location.location_id,
                    room_properties = new List<room_property>()
                    {
                        new room_property()
                        {
                            room_property_name = rumprop
                        }
                        }   
                });
            }
        }

            Console.WriteLine("Making Bookings");

            foreach(var society in db.GetAllSocieties().ToList())
            {
                int noOfBookings = rnd.Next(1, 3);
                for(int i = 0; i < noOfBookings; i++)
                {
                    db.CreateBooking(
                        new booking()
                        {
                            booking_from = DateTime.Today.AddDays(-1),
                            booking_to = DateTime.Today.AddDays(1),
                            society_id = society.society_id,
                            room_id = db.GetRandomRoom().room_id,
                        });
                }
            }


        Console.WriteLine("Done!");

    }
}
}
