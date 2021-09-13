using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleCodingChallenge.Business.Actions.Employees;
using SimpleCodingChallenge.Common.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCodingChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class EmployeesController : Controller
    {
        private readonly IMediator mediator;
        

        //original code, q3
        public EmployeesController(IMediator mediator)
        {
           this.mediator = mediator;
        }

        // my code q3
        public EmployeesController(IMediator mediator)
        {
            this.mediator = mediator;
           
        }



        
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<EmployeeDto>>> Index()
        {
            var result = await mediator.Send(new GetAllEmployeesCommand());
            return result.EmployeeList;
        }

        //q3
        [HttpPost]
        [Route("")]
        //
        public async Task<ActionResult<EmployeeDto>> Create(EmployeeDto employeeDto) // this "employeeDto" is not passed to any  mehtod in "AddEmployeesCommandHandler"
        {
            //q3
            // await mediator.Send(new AddEmployeesCommand());
            //return employeeDto;
            //original code :  return null;

            await _mediator.Send(new AddEmployeesCommand(employeeDto));
            return employeeDto;

        }


       // [HttpPut("{EmployeeID}")]
        //[Route("")]
        //public async Task<ActionResult> Create(string EmployeeID, AddEmployeesCommand command)
        //{
          //  if (EmployeeID != command.EmployeeID)
            //{
              //  return BadRequest();
            //}
            //return Ok(await mediator.Send(command));
        //}
    }

    [HttpGet("{id}")]
     [Route("{id}")]
public async Task<ActionResult<EmployeeDto>> GetById(string employeeId)
{

        var result = await mediator.Send(new GetEmployeeByIdCommand( employeeId));
        if (result == null)
        {
            return NotFound();
        }
            return result.;
}
}
