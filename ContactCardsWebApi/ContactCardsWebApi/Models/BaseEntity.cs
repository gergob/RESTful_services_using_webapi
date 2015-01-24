using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactCardsWebApi.Models
{
    public class BaseEntity
    {
        [BsonElement(elementName: "_id")]
        [BsonId(IdGenerator=typeof(GuidGenerator))]
        [BsonRequired]
        public Guid ID { get; set; }

        public BaseEntity()
        {
           
        }

        public BaseEntity(Guid id)
        {
            this.ID = id;
        }

    }
}