using System.Collections.Generic;
using BankSystem.Application.DataTransferObjects;
using BankSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserApplicationService _userApplicationService;

        public UserController(IUserApplicationService userApplicationService) 
            => _userApplicationService = userApplicationService;

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> Get()
        {
            return Ok(_userApplicationService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            var user = _userApplicationService.GetBy(id);
            
            if (user == null) return NotFound();
            return Ok(user);
        }


        [HttpPost]
        public ActionResult Post([FromBody] [Bind("Name")] UserDTO userDTO)
        {
            if (userDTO == null) return NotFound();

            _userApplicationService.Add(userDTO);

            return Ok("User created with success!");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] [Bind("Name")] UserDTO userDTO)
        {
            if (userDTO == null) return NotFound();

            _userApplicationService.Update(id, userDTO);

            return Ok("User updated with success!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _userApplicationService.Remove(id);

            return Ok("User deleted with success!");
        }
    }
}