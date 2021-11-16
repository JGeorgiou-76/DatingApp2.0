using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    //[Authorize]
    public class UsersController : ControllerBase //BaseApiController
    {
        // private readonly IUserRepository _userRepository;
        // private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UsersController(DataContext context)//IUserRepository userRepository, IMapper mapper)
        {
            _context = context;
            // _mapper = mapper;
            // _userRepository = userRepository;
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
            return await _context.Users.ToListAsync(); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id){
            return await _context.Users.FindAsync(id); 
        }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<MemberDTO>>> GetUsers()
        // {
        //     var users = await _userRepository.GetMembersAsync();

        //     return Ok(users);
        // }

        // [HttpGet("{username}")]
        // public async Task<ActionResult<MemberDTO>> GetUser(string username)
        // {
        //     return await _userRepository.GetMemberAsync(username);

        // }
    }
}