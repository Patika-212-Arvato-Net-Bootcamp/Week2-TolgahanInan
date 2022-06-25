using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week2_Tolgahaninan.Models;
using Week2_Tolgahaninan.Models.Dtos;
using Week2_Tolgahaninan.Repository.IRepository;

namespace Week2_Tolgahaninan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        private IBootcampRepository _bootcampRepository;
        private readonly IMapper _mapper;

        public AdminApiController(IBootcampRepository bootcampRepository , IMapper mapper)
        {
            _bootcampRepository = bootcampRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateBootcamp([FromBody] BootcampDto bootcampDto )
        {
           if (bootcampDto == null)
            {
                return BadRequest(ModelState);
            }
           if (_bootcampRepository.BootcampExists(bootcampDto.Name))
            {
                ModelState.AddModelError("", "Bootcamp Exists");
                return StatusCode(404, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bootcampObj = _mapper.Map<Bootcamp>(bootcampDto);

            if (!_bootcampRepository.CreateBootcamp(bootcampObj))
            {
                ModelState.AddModelError("", $"Something Went Wrong while saving {bootcampObj.Name}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
        [HttpPut("{bootcampId:int}")]
        public IActionResult UpdateBootcamp(int bootcampId , [FromBody] BootcampDto bootcampDto)
        {
            if (bootcampDto == null || bootcampId != bootcampDto.Id)
            {
                return BadRequest(ModelState);
            }
            var bootcampObj = _mapper.Map<Bootcamp>(bootcampDto);
            if (!_bootcampRepository.UpdateBootcamp(bootcampObj))
            {
                ModelState.AddModelError("", $"Something Went Wrong while updating {bootcampObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{bootcampId:int}")]
        public IActionResult DeleteBootcamp(int bootcampId)
        {
            if (!_bootcampRepository.BootcampExists(bootcampId))
            {
                return NotFound();
            }
            var bootcampObj = _bootcampRepository.GetBootcamp(bootcampId);

            if (!_bootcampRepository.DeleteBootcamp(bootcampObj))
            {
                ModelState.AddModelError("", $"Something Went Wrong while Deleting {bootcampObj.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
