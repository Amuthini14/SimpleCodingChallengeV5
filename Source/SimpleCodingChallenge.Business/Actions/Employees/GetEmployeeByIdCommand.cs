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
    public class GetEmployeeByIdCommand : IRequest<GetEmployeeByIdCommandResponse>
    {
        public string employeeId;

        public  GetEmployeeByIdCommand(string employeeId)
        {
            this.employeeId = employeeId;
        }

    }

    public class GetEmployeeByIdCommandResponse
    {
        public EmployeeDto employeeDto { get; set; }
    }

    public class GetEmployeeByIdCommandHandler : IRequestHandler<GetEmployeeByIdCommand, GetEmployeeByIdCommandResponse>
    {
        private readonly SimpleCodingChallengeDbContext dbContext;
        private readonly IMapper mapper;

        public GetEmployeeByIdCommandHandler(SimpleCodingChallengeDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<GetEmployeeByIdCommandResponse> Handle(GetEmployeeByIdCommand request, CancellationToken cancellationToken)
        {
            
            //

            var employee = await dbContext.Employees.FindAsync(request.employeeId);
            var employeeDto_result = mapper.Map<EmployeeDto>(employee);
            return new GetEmployeeByIdCommandResponse
            {
                employeeDto = employeeDto_result;
            }
        }
    }
}
