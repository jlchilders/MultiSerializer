using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ProtoBuf;
namespace Models
{
    [ProtoContract]
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

        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        [Display(Name = "First name"), Required]
        public string FirstName { get; set; }

        [ProtoMember(3)]
        [Display(Name = "Last name"), Required]
        public string LastName { get; set; }

        [ProtoMember(4)]
        [Display(Name = "Street address"), Required]
        public string StreetAddress { get; set; }

        [ProtoMember(5)]
        [Required]
        public string City { get; set; }

        [ProtoMember(6)]
        [Required]
        public string State { get; set; }

        [ProtoMember(7)]
        [Display(Name = "Zip code"), Required, MinLength(5, ErrorMessage = "Zip code must be at least five digits.")]
        public int ZipCode { get; set; }

        [Display(Name ="Serialize to:")]
        public SerializeTo serializeTo { get; set; }

        public enum SerializeTo
        {
            Protobuf,
            XML,
            Json
        }
        public string Serialized { get; set; }

    }
}