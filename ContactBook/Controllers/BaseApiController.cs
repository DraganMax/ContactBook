using AutoMapper;
using ContactBook.core.Services;
using System.Web.Http;

namespace ContactBook.Controllers
{
    public class BaseApiController : ApiController
    {
        protected readonly IMapper _mapper;
        protected readonly IContactService _contactService;
        public BaseApiController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
    }
}
