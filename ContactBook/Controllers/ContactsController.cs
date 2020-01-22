using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using ContactBook.core.Models;
using ContactBook.core.Services;
using ContactBook.data.Models;
using ContactBook.Models;

namespace ContactBook.Controllers
{
    public class ContactsController : BaseApiController
    {
        public ContactsController(IContactService contactService, IPhoneService phoneService,
            IEmailService emailService, IMapper mapper)
            : base(contactService, phoneService, mapper)
        {

        }

        // GET api/contacts
        [HttpGet]
        [Route("api/contacts")]
        public async Task<IHttpActionResult> GetContacts()
        {
            var contacts = await _contactService.GetContacts();
            return Ok(contacts.Select(f => _mapper.Map<ContactRequest>(f)).ToList());
        }

        // GET api/contacts/5
        [HttpGet]
        [Route("api/contacts/{id}")]
        public async Task<IHttpActionResult> GetContactById(int id)
        {
            var contact = await _contactService.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ContactRequest>(contact));
        }

        [HttpPost]
        [Route("api/contacts")]
        public async Task<IHttpActionResult> AddContact(ContactRequest contact)
        {
            if (!IsValidContact(contact) || !ValidBirthDay(contact) || !ValidPhone(contact))
            {
                return BadRequest();
            }
            
            var result = await _contactService.AddContact(_mapper.Map<Contact>(contact));

            if (!result.Succeeded)
            {
                return Conflict();
            }
            return Created(string.Empty, contact);
        }

        [HttpPut]
        [Route("api/contacts/{id}")]
        public async Task<IHttpActionResult> UpdateContact(ContactRequest contact)
        {
            if (!ValidBirthDay(contact) || !IsValidContact(contact))
            {
                return BadRequest();
            }

            var result = await _contactService.UpdateContact(_mapper.Map<Contact>(contact));
            if (!result.Succeeded)
            {
                return Conflict();
            }
            return Ok(contact);
        }
        [HttpGet]
        [Route("api/contacts")]
        public async Task<IHttpActionResult> SearchContact(string search)
        {
            var contacts = await _contactService.SearchContact(search);
            contacts.Select(a => _mapper.Map<ContactRequest>(a));
            if (contacts == null)
            {
                return NotFound();
            }
            return Ok(contacts.ToList());
        }

        [HttpDelete]
        [Route("api/contacts/{id}")]
        public async Task<IHttpActionResult> DeleteById(int id)
        {
            await _contactService.DeleteContactById(id);
            return Ok();
        }

        [HttpDelete]
        [Route("api/contacts/clear")]
        public async Task<bool> DeleteAllContacts()
        {
            await _contactService.DeleteContacts();
            return true;
        }
    }
}
