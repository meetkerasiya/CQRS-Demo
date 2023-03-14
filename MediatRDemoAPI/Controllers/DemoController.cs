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
    }
}