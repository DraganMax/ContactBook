using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using ContactBook.core.Services;
using ContactBook.data.Models;
using ContactBook.Models;
using ContactBookService.data.Interfaces;

namespace ContactBook.Controllers
{
    public class ContactsController : BaseApiController
    {
        public ContactsController(IContactService contactService, IMapper mapper) : base(contactService, mapper)
        {
        }

        // GET api/contacts
        [HttpGet]
        [Route("api/contacts")]
        public ICollection<ContactRequest> GetContacts() 
        {
            var contacts = _mapper.Map<ICollection<ContactRequest>>(_contactService.Get());
            return contacts;
        }

        // GET api/contacts/5
        [HttpGet]
        [Route("api/contacts/{id}")]
        public IHttpActionResult GetContactById(int id)
        {
            var contact = _mapper.Map<ICollection<ContactRequest>>(_contactService.GetById(id));
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ICollection<ContactRequest>>(contact));
        }

        private bool IsValid(ContactRequest contact)
        {
            return !string.IsNullOrEmpty(contact.Name) &&
                   !string.IsNullOrEmpty(contact.Surname);
        }

        [HttpPut]
        [Route("api/contacts")]
        public async Task<IHttpActionResult> AddContact(ContactRequest contact)
        {
            var result = await _contactService.AddContact(_mapper.Map<ContactRequest>(contact));
            if (!result.Succeeded)
            {
                return Conflict();
            }
            return Created(string.Empty, contact);
        }
    }
}
