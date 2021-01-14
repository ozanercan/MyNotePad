using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNotePad.Business.Abstract;
using MyNotePad.Core.Business.Results.Abstract;
using MyNotePad.Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNotePad.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListAsync()
        {
            var noteDtosResult = await _noteService.GetNoteDtosAsync();

            if (noteDtosResult.ProcessResultType == ProcessResultType.Completed)
            {
                return Ok(noteDtosResult);
            }
            else
            {
                return StatusCode(500, noteDtosResult);
            }
        }

        [HttpPost("get")]
        public async Task<IActionResult> GetAsync(string noteTitle)
        {
            var noteDtoResult = await _noteService.GetDtoByNoteTitleAsync(noteTitle);

            if (noteDtoResult.ProcessResultType == ProcessResultType.Completed)
            {
                return Ok(noteDtoResult);
            }
            else
            {
                return StatusCode(500, noteDtoResult);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(NoteCreateDto noteCreateDto)
        {
            var createResult = await _noteService.CreateNoteAsync(noteCreateDto);

            if (createResult.ProcessResultType == ProcessResultType.Completed)
            {
                return Ok(createResult);
            }
            else
            {
                return BadRequest(createResult);
            }
        }
    }
}
