using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Ongkon.Contracts.Interfaces;

namespace Ongkon.Contracts.Models
{
    public class WhiteBoardQuery : IQuery
    {
        public string Id { get; set; }
        public BsonDocument GetMongoQuery()
        {
            return new BsonDocument("_id", Id);
        }
    }
}
