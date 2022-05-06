using Microsoft.EntityFrameworkCore;
using DAB_ASS3.Models;
using MongoDB.Driver;

namespace MongoContext.Services
{
    public class MongoService
    {
        private IMongoCollection<booking>           _booking;
        private IMongoCollection<society>           _society;
        private IMongoCollection<location>          _location;
        private IMongoCollection<room>              _room;
        private IMongoCollection<room_property>     _room_properties;
        private IMongoCollection<location_property> _location_properties;




        private readonly string connectionString = "mongodb://localhost:27017";
        private readonly string DBname = "DAB-ASS3-Municipality";


        public IMongoCollection<booking> Booking { get { return _booking; } }

        public IMongoCollection<location> Location { get { return _location; } }

        public IMongoCollection<room> Room { get { return _room;} }

        public IMongoCollection<society> Society { get { return _society; } }

        public MongoService()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(DBname);

            _booking =              database.GetCollection<booking>("booking");

            _society =              database.GetCollection<society>("society");

            _location =             database.GetCollection<location>("location");

            _room =                 database.GetCollection<room>("room");

            

        }


        // DROP COLLECTIONS
        public void DropAllCollections()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(DBname);

            database.DropCollection("booking");
            database.DropCollection("society");
            database.DropCollection("location");
            database.DropCollection("room");

        }

        // CREATE COLLECTION OBJECTS

        public void CreateSociety(society society)
        {
            _society.InsertOne(society);
        }

        public void CreateRoom(room room)
        {
            _room.InsertOne(room);
        }

        public void CreateBooking(booking booking)
        {
            _booking.InsertOne(booking);
        }

        public void CreateLocation(location location)
        {
            _location.InsertOne(location);
        }


        // GETTERS

        public society GetSociety(string name)
        {
            return _society.Find<society>(x => x.society_name == name).FirstOrDefault();
        }

        public room GetRoom(string id)
        {
            return _room.Find<room>(x => x.room_id == id).FirstOrDefault();
        }
        

        public location GetLocation(string name)
        {
            return _location.Find<location>(x => x.location_name == name).FirstOrDefault();
        }

        public List<room> GetRoomsFromLocation(string id)
        {
            return _room.Find<room>(x => x.location_ID == id).ToList();
        }

        public List<location> GetAllLocations()
        {
            return _location.Find<location>(x => true).ToList();
        }

        public List<booking> GetAllBookings()
        {
            return _booking.Find(x => true).ToList();
        }

        public List<society> GetAllSocieties()
        {
            return _society.Find(x => true).ToList();

        }

        public List<room> GetAllRooms()
        {

            return _room.Find(x => true).ToList();
        }


        // *SPECIAL* GETTERS

        public room GetRandomRoom()
        {
            var rooms = GetAllRooms();

            Random rnd = new Random();

            return rooms[rnd.Next(0, rooms.Count)];

        }

    }
}







