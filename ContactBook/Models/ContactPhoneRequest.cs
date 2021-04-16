using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactBook.Models
{
    public class ContactPhoneRequest : EntityModel
    {
        public int ContactId { get; set; }
        [Required]
        public string Number { get; set; }
    }
}