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
    //public class EmailsController : BaseApiController
    //{
        //protected IEmailService _emailService;
        //public EmailsController(IContactService contactService, IEmailService emailService, IPhoneService phoneService,
        //    IMapper mapper) 
        //    : base (contactService, phoneService, mapper)
        //{
        //    _emailService = emailService;
        //}
        //[HttpPost]
        //[Route("api/emails")]
        //public async Task<IHttpActionResult> AddEmail(ContactEmailRequest email)
        //{
        //    if (!ValidEmail(email))
        //    {
        //        return BadRequest();
        //    }

        //    var addedEmail = new ContactEmail()
        //    {
        //        Contact = await _contactService.GetContactById(email.ContactId),
        //        Email = email.Email
        //    };
           
        //    var result = await _emailService.AddEmail(_mapper.Map<ContactEmail>(addedEmail));
        //    if (!result.Succeeded)
        //    {
        //        return Conflict();
        //    }
        //    return Created(string.Empty, addedEmail);
        //}
 
    //}
}
