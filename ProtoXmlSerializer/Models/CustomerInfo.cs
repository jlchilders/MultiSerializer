using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProtoBuf;
namespace Models
{
    [ProtoContract]
    public class CustomerInfo
    {
        public string ErrorMessage { get; set; }

        public CustomerInfo()
        {

        }
        public CustomerInfo(string firstName, string lastName, string streetAddress, string city, string state, int zip)
        {
 
            FirstName = firstName;
            LastName = lastName;
            StreetAddress = streetAddress;
            City = city;
            State = state;
            ZipCode = zip;
        }


        [ProtoMember(1)]
        [Display(Name = "First name"), Required]
        public string FirstName { get; set; }

        [ProtoMember(2)]
        [Display(Name = "Last name"), Required]
        public string LastName { get; set; }

        [ProtoMember(3)]
        [Display(Name = "Street address"), Required]
        public string StreetAddress { get; set; }

        [ProtoMember(4)]
        [Required]
        public string City { get; set; }

        [ProtoMember(5)]
        [Required]
        public string State { get; set; }

        [ProtoMember(6)]
        [Display(Name = "Zip code"), Required/*, MinLength(5, ErrorMessage = "Zip code must be at least five digits.")*/]
        public int ZipCode { get; set; }

        [XmlIgnoreAttribute, JsonIgnore]
        [Display(Name ="Serialize to:")]
        public SerializeTo SerializeDirection { get; set; }

        [JsonIgnore]
        public string SelectedDirection { get; set; }

        public enum SerializeTo
        {
            Protobuf,
            XML,
            Json
        }

        [JsonIgnore, AllowHtml]
        public string Serialized { get; set; }

        public string ToString()
        {
            StringBuilder builder = new StringBuilder("");
            builder = builder.AppendFormat("{0} {1}, {2}, {3}, {4} {5}", FirstName, LastName, StreetAddress, City, State, ZipCode);
            return builder.ToString();
      
        }

    }
}