using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTraining1121AngularDemo.Customers.Dtos
{
    public class UsersInCustomerDto : CreationAuditedEntityDto<long>
    {
        public string UserName { get; set; }
    }
}
