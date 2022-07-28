using System;
using System.Collections.Generic;
using System.Text;

namespace MyTraining1121AngularDemo.CustomerUser.Dtos
{
    public class GetAllCustomerUserInput
    {
         public string Filter { get; set; }

        public Decimal? MaxTotalBillingAmountFilter { get; set; }
        public Decimal? MinTotalBillingAmountFilter { get; set; }
    }
}
