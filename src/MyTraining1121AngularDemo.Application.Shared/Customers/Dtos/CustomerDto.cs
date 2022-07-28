using System;
using Abp.Application.Services.Dto;

namespace MyTraining1121AngularDemo.Customers.Dtos
{
    public class CustomerDto : EntityDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public DateTime? RegistrationDate { get; set; }

    }
}