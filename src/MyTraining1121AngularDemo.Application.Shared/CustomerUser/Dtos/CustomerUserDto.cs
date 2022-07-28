using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTraining1121AngularDemo.CustomerUser.Dtos
{
    public class CustomerUserDto : EntityDto
    {
        public int CustomerId { get; set; }

        public int UserId { get; set; }

        public Decimal? TotalBillingAmount { get; set; }
    }
}
