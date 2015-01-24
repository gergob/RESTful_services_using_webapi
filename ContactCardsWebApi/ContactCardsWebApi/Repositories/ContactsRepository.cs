using ContactCardsWebApi.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ContactCardsWebApi.Repositories
{
    public class ContactsRepository
    {
        private const string CONNECTION_STRING = "mongodb://localhost";
        private const string DATABASE = "contact_db";
        private const string COLLECTION_CONTACTS = "contacts";

        private MongoClient client = null;
        private MongoServer server = null;
        private MongoDatabase db = null;
        private MongoCollection<Contact> contacts = null;

        public ContactsRepository()
        {
            client = new MongoClient(CONNECTION_STRING);
            server = client.GetServer();
            db = server.GetDatabase(DATABASE);
            contacts = db.GetCollection<Contact>(COLLECTION_CONTACTS);
        }


        public IEnumerable<Contact> GetAll()
        {
            List<Contact> result = new List<Contact>();
            result = this.contacts.FindAll().ToList();
            return result;
        }

        public Contact Get(Guid id)
        {
            Contact result = null;
            var partialResult = this.contacts.AsQueryable<Contact>()
                                    .Where(p => p.ID == id)
                                    .ToList();

            result = partialResult.Count > 0
                            ? partialResult[0]
                            : null;

            return result;
        }

        public Contact Save(Contact c)
        {
            var result = this.contacts.Save(c);
            if (result.DocumentsAffected == 0 && result.HasLastErrorMessage)
            {
                Trace.TraceError(result.LastErrorMessage);
            }

            return c;
        }

        public Contact Update(Guid id, Contact c)
        {
            var query = Query<Contact>.EQ(p => p.ID, id);
            var update = Update<Contact>.Set(p => p.Birthday, c.Birthday)
                                        .Set(p => p.Email, c.Email)
                                        .Set(p => p.FirstName, c.FirstName)
                                        .Set(p => p.HomePhone, c.HomePhone)
                                        .Set(p => p.LastName, c.LastName)
                                        .Set(p => p.WorkPhone, c.WorkPhone)
                                        .Set(p => p.MobilePhone, c.MobilePhone)
                                        .Set(p => p.Website, c.Website);

            var result = this.contacts.Update(query, update);
            if (result.DocumentsAffected == 0 && result.HasLastErrorMessage)
            {
                Trace.TraceError(result.LastErrorMessage);
            }

            return c;
        }

        public void Delete(Guid id)
        {
            var query = Query<Contact>.EQ(p => p.ID, id);
            var result = this.contacts.Remove(query);
            if (result.DocumentsAffected == 0 && result.HasLastErrorMessage)
            {
                Trace.TraceError(result.LastErrorMessage);
            }
        }

    }
}