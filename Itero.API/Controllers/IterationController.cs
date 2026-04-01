using System.Security.Claims;
using Itero.BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Itero.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class IterationController : ControllerBase
    {
        private int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        private readonly IterationService _iterationService;

        public IterationController(IterationService service)
        {
            _iterationService = service;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var iteration = _iterationService.GetIteration(UserId);

            if (iteration == null) 
                return BadRequest("Is null");

            return Ok(iteration);
        }

        [HttpPost]
        public IActionResult Create()
        {
            var iteration = _iterationService.Create(UserId);

            if (iteration == null)
                return BadRequest("Already exist");

            return Ok(iteration);
        }

        [HttpPost("set")]
        public IActionResult SetValue(int id)
        {
            var success = _iterationService.SetValue(UserId, id);

            if (!success)
                return NotFound();

            return Ok();
        }

        [HttpPost("result")]
        public IActionResult GetResult(int id)
        {
            var result = _iterationService.GetIterationQuestionById(UserId, id);

            return Ok(result);
        }
    }
}
