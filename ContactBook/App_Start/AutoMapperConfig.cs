using AutoMapper;
using ContactBook.core.Models;
using ContactBook.data.Models;
using ContactBook.Models;
using ContactBookService.core.Models;

namespace ContactBook.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Contact, ContactRequest>();
                cfg.CreateMap<ContactRequest, Contact>();
                cfg.CreateMap<ContactAddress, ContactAddressRequest>();
                cfg.CreateMap<ContactAddressRequest, ContactAddress>().ForMember(x => x.Contact, y => y.Ignore());
                cfg.CreateMap<ContactPhone, ContactPhoneRequest>();
                cfg.CreateMap<ContactPhoneRequest, ContactPhone>().ForMember(x => x.Contact, y => y.Ignore());
                cfg.CreateMap<ContactEmail, ContactEmailRequest>();
                cfg.CreateMap<ContactEmailRequest, ContactEmail>().ForMember(x => x.Contact, y => y.Ignore());
                cfg.CreateMap<ContactBook.core.Types.Type, Models.Types.ContactType>();
                cfg.CreateMap<Models.Types.ContactType, ContactBook.core.Types.Type>();
            });
            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}