using Osb.Core.Platform.Common.Entity.Models;

namespace Osb.Core.Platform.Auth.Entity.Models
{
    public class UserInformation : BaseEntity
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string CellPhone { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public static UserInformation Create(long userId, string name, string mail, string cellphone, string zipCode, string Street, string number, string district, string complement, string city, string state)
        {
            return new UserInformation
            {
                UserId = userId,
                Name = name,
                Mail = mail,
                CellPhone = cellphone,
                ZipCode = zipCode,
                Street = Street,
                Number = number,
                District = district,
                Complement = complement,
                City = city,
                State = state
            };
        }
    }
}