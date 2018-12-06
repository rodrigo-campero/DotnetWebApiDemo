using DotnetWebApiDemo.Domain.Validations;
using FluentValidation.Attributes;

namespace DotnetWebApiDemo.Domain.Entities
{
    [Validator(typeof(ClientValidator))]
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
    }
}
