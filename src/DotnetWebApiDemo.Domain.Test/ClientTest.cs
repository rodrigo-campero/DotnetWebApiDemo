using DotnetWebApiDemo.Domain.Entities;
using DotnetWebApiDemo.Domain.Validations;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;

namespace DotnetWebApiDemo.Domain.Test
{
    [TestClass]
    public class ClientTest
    {
        private ClientValidator validator;

        public ClientTest()
        {
            validator = new ClientValidator();
        }

        [TestMethod]
        public void Should_have_error_when_firstName_is_null()
        {
            validator.ShouldHaveValidationErrorFor(client => client.FirstName, null as string);
        }

        [TestMethod]
        public void Should_have_error_when_lastName_is_null()
        {
            validator.ShouldHaveValidationErrorFor(client => client.LastName, null as string);
        }

        [TestMethod]
        public void Should_have_error_when_email_is_null()
        {
            validator.ShouldHaveValidationErrorFor(client => client.Email, null as string);
        }

        [TestMethod]
        public void Should_have_error_when_phone_is_null()
        {
            validator.ShouldHaveValidationErrorFor(client => client.Phone, null as string);
        }

        [TestMethod]
        public void Should_not_have_error_when_invalid_model_is_supplied()
        {
            Client model = new Client
            {
                FirstName = "Rodrigo",
                LastName = "Campero",
                Email = "rodrigocampero.it@gmail.com",
                Gender = Gender.Male,
                Phone = "(11) 96447-7215"
            };
            FluentValidation.Results.ValidationResult validateResult = validator.Validate(model);
            Assert.IsTrue(!validateResult.Errors.Any());
        }

        [TestMethod]
        public void Should_have_error_when_invalid_model_is_supplied()
        {
            Client model = new Client
            {
                FirstName = "Rodrigo",
                LastName = "Campero",
                Email = "rodrigocampero.it@gmail.com",
                Gender = (Gender)5,
                Phone = "(11) 96447-7215"
            };
            FluentValidation.Results.ValidationResult validateResult = validator.Validate(model);
            if (validateResult.Errors.Any())
            {
                StringBuilder errors = new StringBuilder();
                validateResult.Errors.ToList().ForEach(e => errors.AppendLine(string.Format("{0} : {1}", e.PropertyName, e.ErrorMessage)));

                Assert.IsTrue(validateResult.Errors.Any(), "The 'valid' create request has failed validation : - {0}{0}{1}", Environment.NewLine, errors);
            }
            else
            {
                Assert.IsTrue(validateResult.Errors.Any());
            }
        }
    }
}
