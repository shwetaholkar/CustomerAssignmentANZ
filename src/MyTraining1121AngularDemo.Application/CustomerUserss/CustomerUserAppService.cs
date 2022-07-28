using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using MyTraining1121AngularDemo.Customers;
using MyTraining1121AngularDemo.CustomerUser;
using MyTraining1121AngularDemo.CustomerUser.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.CustomerUserss
{
    public class CustomerUserAppService : MyTraining1121AngularDemoAppServiceBase, ICustomerUserAppService
    {
        private readonly IRepository<CustomerUsers> _customerUserRepository;

        public CustomerUserAppService(IRepository<CustomerUsers> customerUserRepository)
        {
            _customerUserRepository = customerUserRepository;
        }

        public async Task CreateOrEdit(CreateOrEditCustomerUserDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        //[AbpAuthorize(AppPermissions.Pages_CustomerUser_Create)]
        protected virtual async Task Create(CreateOrEditCustomerUserDto input)
        {
            var customerUser = ObjectMapper.Map<CustomerUsers>(input);

            if (AbpSession.TenantId != null)
            {
                customerUser.TenantId = (int?)AbpSession.TenantId;
            }

            await _customerUserRepository.InsertAsync(customerUser);

        }

        //[AbpAuthorize(AppPermissions.Pages_CustomerUser_Edit)]
        protected virtual async Task Update(CreateOrEditCustomerUserDto input)
        {
            var customerUser = await _customerUserRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, customerUser);

        }


        // [AbpAuthorize(AppPermissions.Pages_CustomerUser_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _customerUserRepository.DeleteAsync(input.Id);
        }

        public Task<PagedResultDto<GetCustomerUserForViewDto>> GetAll(GetAllCustomerUserInput input)
        {

            //var filteredCustomerUsers = _customerUserRepository.GetAll()
            //           .Include(e =>e.CustomerRef)
            //           .Include(e => e.UserRef)
            //           .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
            //           .WhereIf(input.MinTotalBillingAmountFilter != null, e => e.TotalBillingAmount >= input.MinTotalBillingAmountFilter)
            //           .WhereIf(input.MaxTotalBillingAmountFilter != null, e => e.TotalBillingAmount <= input.MaxTotalBillingAmountFilter)
            //           .WhereIf(!string.IsNullOrWhiteSpace(input.CustomerDisplayPropertyFilter), e => string.Format("{0} {1} {2}", e.CustomerRef == null || e.CustomerRef.Name == null ? "" : e.CustomerRef.Name.ToString()
            //            , e.CustomerRef == null || e.CustomerFk.Email == null ? "" : e.CustomerRef.Email.ToString()
            //            , e.CustomerRef == null || e.CustomerFk.Address == null ? "" : e.CustomerRef.Address.ToString()
            //            ) == input.CustomerDisplayPropertyFilter)
            //           .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserRef != null && e.UserRef.Name == input.UserNameFilter);

            //            var pagedAndFilteredCustomerUsers = filteredCustomerUsers
            //                .OrderBy(input.Sorting ?? "id asc")
            //                .PageBy(input);

            //var customerUsers = from o in pagedAndFilteredCustomerUsers
            //                    join o1 in _lookup_customerRepository.GetAll() on o.CustomerId equals o1.Id into j1
            //                    from s1 in j1.DefaultIfEmpty()

            //                    join o2 in _lookup_userRepository.GetAll() on o.UserId equals o2.Id into j2
            //                    from s2 in j2.DefaultIfEmpty()

            //                    select new
            //                    {

            //                        o.TotalBillingAmount,
            //                        Id = o.Id,
            //                        CustomerDisplayProperty = string.Format("{0} {1} {2}", s1 == null || s1.Name == null ? "" : s1.Name.ToString()
            //    , s1 == null || s1.Email == null ? "" : s1.Email.ToString()
            //    , s1 == null || s1.Address == null ? "" : s1.Address.ToString()
            //    ),
            //                        UserName = s2 == null || s2.Name == null ? "" : s2.Name.ToString()
            //                    };

            //var totalCount = await filteredCustomerUsers.CountAsync();

            //var dbList = await customerUsers.ToListAsync();
            //var results = new List<GetCustomerUserForViewDto>();

            //foreach (var o in dbList)
            //{
            //    var res = new GetCustomerUserForViewDto()
            //    {
            //        CustomerUser = new CustomerUserDto
            //        {

            //            TotalBillingAmount = o.TotalBillingAmount,
            //            Id = o.Id,
            //        },
            //        CustomerDisplayProperty = o.CustomerDisplayProperty,
            //        UserName = o.UserName
            //    };

            //    results.Add(res);
            //}

            //return new PagedResultDto<GetCustomerUserForViewDto>(
            //    totalCount,
            //    results
            //);

            var filteredCustomerUsers = _customerUserRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false)
             
                        .WhereIf(input.MinTotalBillingAmountFilter != null, e => e.TotalBillingAmount >= input.MinTotalBillingAmountFilter)
                        .WhereIf(input.MaxTotalBillingAmountFilter != null, e => e.TotalBillingAmount <= input.MaxTotalBillingAmountFilter);

            var pagedAndFilteredCustomers = filteredCustomerUsers
                .OrderBy(input.Sorting?? "id asc")
                .PageBy(input);
            
            var customerUsers = from o in pagedAndFilteredCustomers
                            select new
                            {
                                o.CustomerId,
                                o.UserId,

                                o.TotalBillingAmount,
                                Id = o.Id
                            };

            var totalCount = await filteredCustomerUsers.CountAsync();

            var dbList = await customerUsers.ToListAsync();
            var results = new List<GetCustomerUserForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetCustomerUserForViewDto()
                {
                    CustomerUser = new CustomerUserDto
                    {
                        CustomerId = o.CustomerId,
                        UserId = o.UserId,
                        TotalBillingAmount = o.TotalBillingAmount,
                        
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetCustomerUserForViewDto>(
                totalCount,
                results
            );

        }

        //[AbpAuthorize(AppPermissions.Pages_CustomerUser_Edit)]
        public async Task<GetCustomerUserForEditOutput> GetCustomerUserForEdit(EntityDto input)
        {
            var customerUser = await _customerUserRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetCustomerUserForEditOutput { CustomerUsers = ObjectMapper.Map<CreateOrEditCustomerUserDto>(customerUser) };
            return output;
        }

        public async Task<GetCustomerUserForViewDto> GetCustomerUserForView(int id)
        {
            var customerUser = await _customerUserRepository.GetAsync(id);
            var output = new GetCustomerUserForViewDto { CustomerUser = ObjectMapper.Map<CustomerUserDto>(customerUser) };
            return output;
        }

    }
}
