using ContactCardsWebApi.Models;
using ContactCardsWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace ContactCardsWebApi.Controllers
{
    public class ContactsController : ApiController
    {
        static readonly ContactsRepository repo = new ContactsRepository();

        //
        // GET api/contacts
        //
        public IEnumerable<Contact> Get()
        {
            return repo.GetAll();
        }

        //
        // GET api/contacts/guid
        //
        public Contact Get(Guid id)
        {
            var contact = repo.Get(id);
            if (contact == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return contact;
        }

        //
        // POST api/contacts
        //
        public HttpResponseMessage Post(Contact value)
        {
            HttpResponseMessage result = null;

            if (ModelState.IsValid)
            {
                try
                {
                    var contact = repo.Save(value);
                    result = Request.CreateResponse<Contact>(HttpStatusCode.Created, contact);
                    string newItemURL = Url.Link("DefaultApi", new { id = contact.ID });
                    result.Headers.Location = new Uri(newItemURL);
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message, ex);
                    result = Request.CreateResponse<string>(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            else
            {
                result = GetBadRequestResponse();
            }

            return result;
        }

        //
        // PUT api/contacts/guid
        //
        public HttpResponseMessage Put(Guid id, Contact value)
        {
            HttpResponseMessage result = null;

            if (ModelState.IsValid)
            {
                try
                {
                    repo.Update(id, value);
                    result = Request.CreateResponse(HttpStatusCode.NoContent);
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message, ex);
                    result = Request.CreateResponse<string>(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            else
            {
                result = GetBadRequestResponse();
            }

            return result;
        }

        //
        // DELETE api/contacts/guid
        //
        public HttpResponseMessage Delete(Guid id)
        {
            HttpResponseMessage result = null;

            try
            {
                repo.Delete(id);
                result = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message, ex);
                result = Request.CreateResponse<string>(HttpStatusCode.InternalServerError, ex.Message);
            }

            return result;
        }

        private HttpResponseMessage GetBadRequestResponse()
        {
            HttpResponseMessage response = null;
            List<string> errors = new List<string>();
            foreach (var modelSt in ModelState.Values)
            {
                foreach (var error in modelSt.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }

            response = Request.CreateResponse<IEnumerable<string>>(HttpStatusCode.BadRequest, errors);
            return response;
        }
    }
}
