using AutoMapper;
using ContactBook.core.Services;
using ContactBook.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
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
        public static bool ValidEmail(ContactEmailRequest email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email.Email);
                return addr.Address == email.Email;
            }
            catch
            {
                return false;
            }
        }
        public static bool ValidPhone(ContactPhoneRequest phone)
        {
            string correctPhone = phone.Number.Trim();
            if (phone == null || string.IsNullOrEmpty(correctPhone) || correctPhone.Any(char.IsLetter)
                || correctPhone.Length < 8 || correctPhone.Length > 8)
                return false;
            return true;
        }
    }
}