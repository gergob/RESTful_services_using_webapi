using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ContactCardsWebApi.Models
{
    public class Contact : BaseEntity
    {
        [BsonElement(elementName: "first_name")]
        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }

        [BsonElement(elementName: "last_name")]
        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }

        [BsonElement(elementName: "birthday")]        
        public DateTime Birthday { get; set; }

        [BsonElement(elementName: "website")]
        [Required]
        [MaxLength(250)]
        public string Website { get; set; }

        [BsonElement(elementName: "email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [BsonElement(elementName: "home_phone")]
        public string HomePhone { get; set; }

        [BsonElement(elementName: "work_phone")]
        public string WorkPhone { get; set; }

        [BsonElement(elementName: "mobile_phone")]
        public string MobilePhone { get; set; }

        public Contact()
            : base()
        {

        }

        public Contact(Guid id)
            : base(id)
        {

        }


        public Contact(string id)
            : base(new Guid(id))
        {

        }

    }
}