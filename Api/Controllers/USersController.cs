using Api.Data;
using Api.Dtos;
using Api.Entity;
using Api.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    // [Authorize]
    public class USersController : BaseApiController
    {
        private readonly DattingContext _context;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public USersController(DattingContext context, IUserRepository repository,IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemeberDto>>> GetUsers()
        {
            var users = await _repository.GetMembersAsync();
            //var usersToReturn = _mapper.Map<IEnumerable<MemeberDto>>(users);
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MemeberDto>> GetUserById(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);
            var rertunuser = _mapper.Map<MemeberDto>(user);
            return Ok(rertunuser);
        }
        [HttpGet("username")]
        public async Task<ActionResult<AppUser>> GetUserByUsername(string username)
        {
            var user = await _repository.GetMemberAsync(username);
            //var rertunuser = _mapper.Map<MemeberDto>(user);
            return Ok( user);
        }

    } 
}

