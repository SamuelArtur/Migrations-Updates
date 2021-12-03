using Osb.Core.Platform.Auth.Service.Models.Request;

namespace Osb.Core.Api.Application.Models.Request
{
    public class UpdateUserInformationRequest : BaseRequest
    {
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
    }
}