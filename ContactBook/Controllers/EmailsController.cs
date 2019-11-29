using AutoMapper;
using ContactBook.core.Models;
using ContactBook.core.Services;
using ContactBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ContactBook.Controllers
{
    public class EmailsController : BaseApiController
    {
        protected IEmailService _emailService;
        public EmailsController(IContactService contactService, IEmailService emailService, IMapper mapper) 
            : base (contactService, mapper)
        {
            _emailService = emailService;
        }
        [HttpPost]
        [Route("api/emails")]
        public async Task<IHttpActionResult> AddEmail(ContactEmailRequest email)
        {
            if (!ValidEmail(email))
            {
                return BadRequest();
            }

            var addedEmail = new ContactEmail()
            {
                Contact = await _contactService.GetContactById(email.ContactId),
                Email = email.Email
            };
           
            var result = await _emailService.AddEmail(_mapper.Map<ContactEmail>(addedEmail));
            if (!result.Succeeded)
            {
                return Conflict();
            }
            return Created(string.Empty, addedEmail);
        }
        [HttpDelete]
        [Route("api/emails/{id}")]
        public async Task<IHttpActionResult> DeleteById(int id)
        {
            await _emailService.DeleteEmailById(id);
            return Ok();
        }
        [HttpPut]
        [Route("api/emails/{id}")]
        public async Task<IHttpActionResult> UpdateEmail(ContactEmailRequest email)
        {
            if (!ValidEmail(email))
            {
                return BadRequest();
            }

            var result = await _emailService.UpdateEmail(_mapper.Map<ContactEmail>(email));
            if (!result.Succeeded)
            {
                return Conflict();
            }
            return Ok(email);
        }
    }
}
