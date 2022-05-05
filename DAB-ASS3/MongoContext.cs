using Microsoft.EntityFrameworkCore;
using DAB_ASS3.Models;
using MongoDB.Driver;

namespace MongoContext.Services
{
    public class BookService
    {
        private IMongoCollection<Booking> _booking;
        private readonly string connectionString = "mongodb://localhost:27017";
        private readonly string DBname = "DAB-ASS3-Municipality";
        private readonly string collection = "Booking";

        public BookService()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(DBname);
            _booking = database.GetCollection<Booking>(collection);
        }


    }
}







