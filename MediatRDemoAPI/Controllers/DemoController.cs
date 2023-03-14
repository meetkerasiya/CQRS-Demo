using DemoLibrary.Commands;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatRDemoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DemoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult GetPeople()
        {
            var people = _mediator.Send(new GetPersonListQuery());
            return Ok(people.Result);
        }

        [HttpGet("{id}")]
        public IActionResult GetPeopleById(int id)
        {
            var person=_mediator.Send(new GetPersonByIdQuery(id));
            return Ok(person.Result);
        }

        [HttpPost]
        public IActionResult AddPerson([FromBody] PersonModel value)
        {
            var model=new InsertPersonCommand(value.FirstName, value.LastName);
            var result= _mediator.Send(model);
            return Ok(result.Result);
        }
    }
}