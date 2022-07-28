using Abp.Application.Services.Dto;
using System;

namespace MyTraining1121AngularDemo.Customers.Dtos
{
    public class GetAllCustomersForExcelInput
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }

        public string EmailFilter { get; set; }

        public string AddressFilter { get; set; }

        public DateTime? MaxRegistrationDateFilter { get; set; }
        public DateTime? MinRegistrationDateFilter { get; set; }

    }
}