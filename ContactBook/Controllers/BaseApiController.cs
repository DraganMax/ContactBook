using AutoMapper;
using ContactBook.core.Services;
using ContactBook.Models;
using System;
using System.Linq;
using System.Net.Mail;
using System.Web.Http;

namespace ContactBook.Controllers
{
    public class BaseApiController : ApiController
    {
        protected readonly IMapper _mapper;
        protected readonly IContactService _contactService;
        protected readonly IPhoneService _phoneService;
        //protected readonly IEmailService _emailService;

        public BaseApiController(IContactService contactService,
            IPhoneService phoneService,// IEmailService emailService,
            IMapper mapper)
        {
            _contactService = contactService;
            _phoneService = phoneService;
            //_emailService = emailService;
            _mapper = mapper;
        }

        public static bool IsValidContact(ContactRequest contact)
        {
            if (contact == null || string.IsNullOrEmpty(contact.Name) || string.IsNullOrEmpty(contact.Surname)
                || contact.Name.Any(char.IsDigit) || contact.Surname.Any(char.IsDigit))
                return false;

            return true;
        }

        public static bool ValidBirthDay(ContactRequest contact)
        {
            var birthDayDate = contact.Birthday;
            var todayDate = DateTime.Today;
            return DateTime.Compare(Convert.ToDateTime(birthDayDate), todayDate) <= 0;
        }

        public static bool ValidEmail(ContactRequest email)
        {
            try
            {
                bool validEmail = true;
                var emails = email.Emails.Select(e => e.Email);
                foreach (var e in emails)
                {
                    var addr = new MailAddress(e);
                    validEmail = addr.Address == e;
                }
                return validEmail;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidPhone(ContactRequest contact)
        {
            var phones = contact.Phones.Select(a => a.Number.Trim());
            foreach(var number in phones)
            {
                if (phones == null || string.IsNullOrEmpty(number) || number.Any(char.IsLetter)
                || number.Length != 8 || number[0] != '2')
                return false;
            }

            return true;
        }
    }
}