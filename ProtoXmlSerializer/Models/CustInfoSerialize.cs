using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Models
{
    public class CustInfoSerialize
    {
        public string ErrorMessage { get; set; }

        public CustInfoSerialize(int id, string firstName, string lastName, string streetAddress, string city, string state, int zip)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            StreetAddress = streetAddress;
            City = city;
            State = state;
            ZipCode = zip;
        }

        public int Id { get; set; }

        [Display(Name = "First name"), Required]
        public string FirstName { get; set; }

        [Display(Name = "Last name"), Required]
        public string LastName { get; set; }

        [Display(Name = "Street address"), Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Display(Name = "Zip code"), Required, MinLength(5, ErrorMessage = "Zip code must be at least five digits.")]
        public int ZipCode { get; set; }

        public string Serialized { get; set; }

    }
}