using System;
using ContactBook.Controllers;
using ContactBook.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactBook.Tests
{
    [TestClass]
    public class ContactValidationTest
    {
        [TestMethod]
        public void IsValidContactTest()
        {
            ContactRequest emptyName = new ContactRequest() { Name = "", Surname = "Sad" };
            ContactRequest nameIsNull = new ContactRequest() { Name = null, Surname = "Taube" };
            ContactRequest surnameIsNull = new ContactRequest() { Name = "Gatis", Surname = null };
            ContactRequest wrongFormat = new ContactRequest() { Name = "123", Surname = "42Dar"};
            ContactRequest contactNull = null;
            ContactRequest correctContact = new ContactRequest() { Name = "Rihards", Surname = "Valida" };

            Assert.IsFalse(BaseApiController.IsValidContact(emptyName));
            Assert.IsFalse(BaseApiController.IsValidContact(nameIsNull));
            Assert.IsFalse(BaseApiController.IsValidContact(surnameIsNull));
            Assert.IsFalse(BaseApiController.IsValidContact(wrongFormat));
            Assert.IsFalse(BaseApiController.IsValidContact(contactNull));
            Assert.IsTrue(BaseApiController.IsValidContact(correctContact));
        }

        [TestMethod]
        public void ValidBirthDayTest()
        {
            ContactRequest contactWithImpossibleBirthday = new ContactRequest() { Birthday = new DateTime(2020, 10, 10) };
            ContactRequest contactWithRealBirthday = new ContactRequest() { Birthday = new DateTime(2019, 11, 10) };

            Assert.IsFalse(BaseApiController.ValidBirthDay(contactWithImpossibleBirthday));
            Assert.IsTrue(BaseApiController.ValidBirthDay(contactWithRealBirthday));
        }
        [TestMethod]
        public void ValidEmailTest()
        {
            ContactEmailRequest validEmail = new ContactEmailRequest() { Email = "dadad@gmail.com" };
            ContactEmailRequest invalidEmail = new ContactEmailRequest() { Email = "sas.gmail.com" };
            ContactEmailRequest emailNull = new ContactEmailRequest() { Email = null };

            Assert.IsFalse(BaseApiController.ValidEmail(emailNull));
            Assert.IsFalse(BaseApiController.ValidEmail(invalidEmail));
            Assert.IsTrue(BaseApiController.ValidEmail(validEmail));
        }
        [TestMethod]
        public void ValidPhoneTest()
        {
            ContactPhoneRequest validPhone = new ContactPhoneRequest() { Number = "26122360" };
            ContactPhoneRequest invalidPhone = new ContactPhoneRequest() { Number = "228 32  " };
            ContactPhoneRequest wrongFormat = new ContactPhoneRequest() { Number = "252345ba" };

            Assert.IsFalse(BaseApiController.ValidPhone(wrongFormat));
            Assert.IsFalse(BaseApiController.ValidPhone(invalidPhone));
            Assert.IsTrue(BaseApiController.ValidPhone(validPhone));
        }
    }
}
