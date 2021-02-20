using System.Collections.Generic;
using BankSystem.Application.DataTransferObjects;
using BankSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionApplicationService _transactionApplicationService;

        public TransactionController(ITransactionApplicationService transactionApplicationService) 
            => _transactionApplicationService = transactionApplicationService;

        [HttpGet]
        public ActionResult<IEnumerable<TransactionDTO>> Get()
        {
            return Ok(_transactionApplicationService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<TransactionDTO> Get(int id)
        {
            return Ok(_transactionApplicationService.GetBy(id));
        }


        [HttpPost]
        public ActionResult Post([FromBody] TransactionDTO transactionDTO)
        {
            if (transactionDTO == null) return NotFound();

            _transactionApplicationService.Add(transactionDTO);

            return Ok("Transaction created with success!");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TransactionDTO transactionDTO)
        {
            if (transactionDTO == null) return NotFound();

            _transactionApplicationService.Update(id, transactionDTO);

            return Ok("Transaction udpated with success!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _transactionApplicationService.Remove(id);

            return Ok("Transaction deleted with success!");
        }
    }
}