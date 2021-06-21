namespace ContactBook.Models
{
    public class ContactAddressRequest : EntityModel
    {
        public int ContactId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }
}