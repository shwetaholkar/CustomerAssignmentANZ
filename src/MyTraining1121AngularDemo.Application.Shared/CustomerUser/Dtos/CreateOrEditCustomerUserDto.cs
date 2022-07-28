using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTraining1121AngularDemo.CustomerUser.Dtos
{
    public class CreateOrEditCustomerUserDto : EntityDto<int?>
    {
        public int CustomerId { get; set; }
        
        public long UserId { get; set; }
    
        public Decimal? TotalBillingAmount { get; set; }

    }
}
