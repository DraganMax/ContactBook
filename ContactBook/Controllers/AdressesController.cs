using AutoMapper;
using ContactBook.core.Models;
using ContactBook.core.Services;
using ContactBook.Models;
using ContactBookService.core.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace ContactBook.Controllers
{
    public class AdressesController : BaseApiController
    {
        protected readonly IAdressService _adressService;
        public AdressesController(IContactService contactService, IAdressService adressService, IMapper mapper)
            : base (contactService, mapper)
        {
            _adressService = adressService;
        }

        [HttpPost]
        [Route("api/adresses")]
        public async Task<IHttpActionResult> AddAdress(ContactAdressRequest adress)
        {
            var addedAdress = new ContactAdress()
            {
                Contact = await _contactService.GetContactById(adress.ContactId),
                City = adress.City,
                Street = adress.Street,
                House = adress.House
            };
            var result = await _adressService.AddAdress(_mapper.Map<ContactAdress>(addedAdress));
            if (!result.Succeeded)
            {
                return Conflict();
            }
            return Created(string.Empty, addedAdress);
        }

        [HttpDelete]
        [Route("api/adresses/{id}")]
        public async Task<IHttpActionResult> DeleteById(int id)
        {
            await _adressService.DeleteAdressById(id);
            return Ok();
        }

        [HttpPut]
        [Route("api/adresses/{id}")]
        public async Task<IHttpActionResult> UpdateAdress(ContactAdressRequest adress)
        {
            var result = await _adressService.UpdateAdress(_mapper.Map<ContactAdress>(adress));
            if (!result.Succeeded)
            {
                return Conflict();
            }
            return Ok(adress);
        }
    }
}
