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
    public class BootCampApiController : ControllerBase
    {

        private IBootcampRepository _bootcampRepository;
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public BootCampApiController(IBootcampRepository bootcampRepository, IMapper mapper , IUserRepository userRepository)
        {
            _bootcampRepository = bootcampRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult getBootcamps()
        {
            var objList = _userRepository.GetBootcamps();
            var objDto = new List<BootcampDto>();
            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<BootcampDto>(obj));
            }
            return Ok(objList);
        }
        [HttpGet("{bootcampId:int}")]
        public IActionResult getBootcamp(int bootcampId)
        {
            var obj = _userRepository.GetBootcamp(bootcampId);
            if(obj == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<BootcampDto>(obj);
            return Ok(objDto);
        }

        [HttpPost("{bootcampId:int}")]
        public IActionResult JoinBootcamp( int bootcampId,int userId)
        {
            if (bootcampId == null || userId==null)
            {
                return BadRequest(ModelState);
            }
            if (!_bootcampRepository.BootcampExists(bootcampId) || !_userRepository.UserExists(userId))
            {
                ModelState.AddModelError("", "Bootcamp or User not Exists");
                return StatusCode(404, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_userRepository.JoinBootcamp(bootcampId,userId))
            {
                ModelState.AddModelError("", $"Something Went Wrong while joining bootcamp id : by ");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

    }
}
