using System.Collections.Generic;
using BankSystem.Application.DataTransferObjects;
using BankSystem.Application.Interfaces;
using BankSystem.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountApplicationService _accountApplicationService;

        public AccountController(IAccountApplicationService accountApplicationService) 
            => _accountApplicationService = accountApplicationService;

        [HttpGet]
        public ActionResult<IEnumerable<AccountDTO>> Get()
        {
            return Ok(_accountApplicationService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<AccountDTO> Get(int id)
        {
            var account = _accountApplicationService.GetBy(id);

            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpGet("User/{userId}")]
        public ActionResult<Account> GetByUserId(int userId)
        {
            var account = _accountApplicationService.GetByUserId(userId);

            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpPost]
        public ActionResult Post([FromBody] AccountDTO accountDTO)
        {
            if (accountDTO == null) return NotFound();

            _accountApplicationService.Add(accountDTO);

            return Ok("Account created with success!");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AccountDTO accountDTO)
        {
            if (accountDTO == null) return NotFound();

            _accountApplicationService.Update(id, accountDTO);

            return Ok("Account updated with success!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _accountApplicationService.Remove(id);

            return Ok("Account deleted with success!");
        }
    }
}