
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
        public List<EmployeeDto> EmployeeList { get; set; }
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string JobTitle { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
        public string FullName { get; set; }
    }

    public class AddEmployeesCommandResponse
    {
        public List<EmployeeDto> EmployeeList { get; set; }
      // public Employee EmployeeList { get; set; }
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
            await dbContext.AddAsync(request.EmployeeList);
            return new AddEmployeesCommandResponse
            {
                EmployeeList = EmployeeList
            };
        }
    }
}








