using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTraining1121AngularDemo.CustomerUser.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.CustomerUser
{
    public interface ICustomerUserAppService : IApplicationService
    {
        Task<GetCustomerUserForViewDto> GetCustomerUserForView(int id);

        Task<PagedResultDto<GetCustomerUserForViewDto>> GetAll(GetAllCustomerUserInput input);

        Task<GetCustomerUserForEditOutput> GetCustomerUserForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditCustomerUserDto input);

        Task Delete(EntityDto input);

    }
}
