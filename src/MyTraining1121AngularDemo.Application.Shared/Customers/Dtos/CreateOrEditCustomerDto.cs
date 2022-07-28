using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyTraining1121AngularDemo.Customers.Dtos
{
    public class CreateOrEditCustomerDto : EntityDto<int?>
    {

        [Required]
        [StringLength(CustomerConsts.MaxNameLength, MinimumLength = CustomerConsts.MinNameLength)]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public DateTime? RegistrationDate { get; set; }

    }
}