using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using MyTraining1121AngularDemo.Authorization.Users;
using System.Collections.Generic;

namespace MyTraining1121AngularDemo.Customers
{
    [Table("Customers")]
    public class Customer : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Required]
        [StringLength(CustomerConsts.MaxNameLength, MinimumLength = CustomerConsts.MinNameLength)]
        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual string Address { get; set; }

        public virtual DateTime? RegistrationDate { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}


