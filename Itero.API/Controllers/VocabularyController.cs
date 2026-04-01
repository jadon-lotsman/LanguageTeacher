using System.Security.Claims;
using Itero.BusinessLogic.DTOs;
using Itero.BusinessLogic.Services;
using Itero.BusinessLogic;
using Itero.DataAccess.Data;
using Itero.DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Itero.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class VocabularyController : ControllerBase
    {
        private int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        private readonly VocabularyService _vocabularyService;

        public VocabularyController(VocabularyService service)
        {
            _vocabularyService = service;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var entries = _vocabularyService.GetAll(UserId);

            return Ok(entries);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entry = _vocabularyService.GetById(UserId, id);

            if (entry == null)
                return NotFound();

            return Ok(entry);
        }

        [HttpPost]
        public IActionResult Create(VocabularCreateDTO dto)
        {
            var result = _vocabularyService.Create(UserId, dto);

            if (result == null)
                return BadRequest("Already exist");

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(int id, VocabularUpdateDTO dto)
        {
            var result = _vocabularyService.Update(UserId, id, dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var success = _vocabularyService.Remove(UserId, id);

            if(!success)
                return NotFound();

            return NoContent();
        }
    }
}
