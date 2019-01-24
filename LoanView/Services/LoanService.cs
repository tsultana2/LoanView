using System.Collections.Generic;
using System.Linq;
using LoanView.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LoanView.Services
{
    public class LoanService
    {
        private readonly IMongoCollection<LoanItem> _loan;

        public LoanService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("LoanDB"));
            var database = client.GetDatabase("LoanDB");
            _loan = database.GetCollection<LoanItem>("Loans");
        }

        public List<LoanItem> Get()
        {
            return _loan.Find(book => true).ToList();
        }

        public LoanItem Get(string id)
        {
            var docId = new ObjectId(id);

            return _loan.Find<LoanItem>(book => book.Id == docId).FirstOrDefault();
        }

        public LoanItem Create(LoanItem loan)
        {
            _loan.InsertOne(loan);
            return loan;
        }

        public void Update(string id, LoanItem loanIn)
        {
            var docId = new ObjectId(id);

            _loan.ReplaceOne(LoanItem => LoanItem.Id == docId, loanIn);
        }

        public void Remove(LoanItem loanIn)
        {
            _loan.DeleteOne(LoanItem => LoanItem.Id == loanIn.Id);
        }

        public void Remove(ObjectId id)
        {
            _loan.DeleteOne(LoanItem => LoanItem.Id == id);
        }
    }
}