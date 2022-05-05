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
        private IMongoCollection<room_properties>   _room_properties;
        private IMongoCollection<location_property> _location_properties;



        private readonly string connectionString = "mongodb://localhost:27017";
        private readonly string DBname = "DAB-ASS3-Municipality";


        public MongoService()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(DBname);

            _booking =              database.GetCollection<booking>("booking");

            _society =              database.GetCollection<society>("society");

            _location =             database.GetCollection<location>("location");

            _room =                 database.GetCollection<room>("room");

            _room_properties =      database.GetCollection<room_properties>("room_property");

            _location_properties =  database.GetCollection<location_property>("location_property");
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

        public void CreateBooking(booking booking, society society, room room)
        {
            booking.society_id = GetSociety(society.society_name).society_id;
            booking.room_id = GetRoom(room.room_name).room_id;


            _booking.InsertOne(booking);
        }

        public void CreateLocation(location location)
        {
            _location.InsertOne(location);
        }

        public void CreateRoomProperty(room_properties room_prop)
        {
            _room_properties.InsertOne(room_prop);
        }

        public void CreateLocationProperty(location_property location_prop)
        {
            _location_properties.InsertOne(location_prop);
        }


        // ASSOCIATION OF COLLECTION OBJECTS

        public void AddRoomPropertyToRoom(room aRoom, room_properties aRoomProp)
        {
            room newRoom = GetRoom(aRoom.room_name);

            room_properties newProp = GetRoomProp(aRoomProp.room_property_name);

            newRoom.room_properties.Add(newProp.roomproperties_id);
            newProp.room_ids.Add(newRoom.room_id);

            _room.ReplaceOne(x => x.room_id == newRoom.room_id, newRoom);
            _room_properties.ReplaceOne(x => x.roomproperties_id == newProp.roomproperties_id, newProp);
        }

        public void AddLocationPropertyToLocation(location aLocation, location_property aLocationProp)
        {
            // Add prop to location

            // Add location to prop
        }


        // GETTERS

        public society GetSociety(string name)
        {
            return _society.Find<society>(x => x.society_name == name).FirstOrDefault();
        }

        public room GetRoom(string name)
        {
            return _room.Find<room>(x => x.room_name == name).FirstOrDefault();
        }

        public location GetLocation(string name)
        {
            return _location.Find<location>(x => x.location_name == name).FirstOrDefault();
        }

        public List<booking> GetBookings()
        {
            return _booking.Find(x => true).ToList();
        }

        public room_properties GetRoomProp(string name)
        {
            return _room_properties.Find<room_properties>(x => x.room_property_name == name).FirstOrDefault();
        }

        public location_property GetLocationProp(string name)
        {
            return _location_properties.Find<location_property>(x => x.location_property_name == name).FirstOrDefault();
        }




    }
}







