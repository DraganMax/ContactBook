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
    //public class PhonesController : BaseApiController
    //{
        //public PhonesController(IContactService contactService, IPhoneService phoneService, IMapper mapper)
        //    : base(contactService, phoneService, mapper)
        //{

        //}

        //[HttpPost]
        //[Route("api/phones")]
        //public async Task<IHttpActionResult> AddPhone(ContactPhoneRequest phone)
        //{
        //    if (!ValidPhone(phone))
        //    {
        //        return BadRequest();
        //    }
        //    var addedPhone = new ContactPhone()
        //    {
        //        Contact = await _contactService.GetContactById(phone.ContactId),
        //        Number = phone.Number
        //    };
        //    var result = await _phoneService.AddPhone(_mapper.Map<ContactPhone>(addedPhone));
        //    if (!result.Succeeded)
        //    {
        //        return Conflict();
        //    }
        //    return Created(string.Empty, addedPhone);
        //}

        //[HttpDelete]
        //[Route("api/phones/{id}")]
        //public async Task<IHttpActionResult> DeleteById(int id)
        //{
        //    await _phoneService.DeletePhoneById(id);
        //    return Ok();
        //}

        //[HttpPut]
        //[Route("api/phones/{id}")]
        //public async Task<IHttpActionResult> UpdatePhone(ContactPhoneRequest phone)
        //{
        //    if (!ValidPhone(phone))
        //    {
        //        return BadRequest();
        //    }

        //    var result = await _phoneService.UpdatePhone(_mapper.Map<ContactPhone>(phone));
        //    if (!result.Succeeded)
        //    {
        //        return Conflict();
        //    }
        //    return Ok(phone);
        // }
      // }
   }
