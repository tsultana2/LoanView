using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LoanView.Models
{
    public class LoanItem
    {
        public ObjectId Id { get; set; }

        [BsonElement("LoanName")]
        public string LoanName { get; set; }

        [BsonElement("LoanComplete")]
        public bool IsComplete { get; set; }

        [BsonElement("LoanStatus")]
        public string LoanStatus { get; set; }

        [BsonElement("ApplicantName")]
        public string ApplicantName { get; set; }

        [BsonElement("CurrentStage")]
        public int currentStage { get; set; }

    }
}
