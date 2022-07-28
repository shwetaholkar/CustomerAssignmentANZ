using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MyTraining1121AngularDemo.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Customers
{
    public class CustomerUsers : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer CustomerRef { get; set; }

        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User UserRef { get; set; }

        public Decimal? TotalBillingAmount { get; set; }

    }
}
