
// q3
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCodingChallenge.Common.DTO;
using SimpleCodingChallenge.DataAccess.Database;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCodingChallenge.Business.Actions.Employees
{
    public class AddEmployeesCommand : IRequest<AddEmployeesCommandResponse>
    {
        // public EmployeeDto EmployeeList { get; set; }
        public EmployeeDto employeeDto;
    }

    public class AddEmployeesCommandResponse
    {
        // public List<EmployeeDto> EmployeeList { get; set; }
        // public Employee EmployeeList { get; set; }

        public bool check_true;
    }
    public class AddEmployeesCommandHandler : IRequestHandler<AddEmployeesCommand, AddEmployeesCommandResponse>
    {
        private readonly SimpleCodingChallengeDbContext dbContext;
        private readonly IMapper mapper;

        public AddEmployeesCommandHandler(SimpleCodingChallengeDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<AddEmployeesCommandResponse> Handle(AddEmployeesCommand request, CancellationToken cancellationToken)
        {
           
            //
            await dbContext.AddAsync(request.employeeDto);
            return new AddEmployeesCommandResponse(
                {
                check_true = true;
            });
        }
    }
}








