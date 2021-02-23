using System;
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
            var transaction = _transactionApplicationService.GetBy(id);
            
            if (transaction == null) return NotFound();
            return Ok(transaction);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TransactionDTO transactionDTO)
        {
            if (transactionDTO == null) return NotFound();

            _transactionApplicationService.Add(transactionDTO);

            return Ok("Transaction created with success!");
        }

        [HttpPost("Deposit")]
        public ActionResult Deposit([FromBody] TransactionDTO transactionDTO)
        {
            if (transactionDTO == null) return NotFound();
            if (transactionDTO.Value < 0) return Content("Value must be greater than zero!");

            _transactionApplicationService.Deposit(transactionDTO);

            return Ok("Transaction Deposit was a success!");
        }

        [HttpPost("Payment")]
        public ActionResult Payment([FromBody] TransactionDTO transactionDTO)
        {
            if (transactionDTO == null) return NotFound();
            if (transactionDTO.Value < 0) return Content("Value must be greater than zero!");

            try 
            {
                _transactionApplicationService.Payment(transactionDTO);
            } 
            catch (Exception exception) 
            {
                return BadRequest(exception.Message);
            }

            return Ok("Transaction Payment was a success!");
        }

        [HttpPost("Withdraw")]
        public ActionResult Withdraw([FromBody] TransactionDTO transactionDTO)
        {
            if (transactionDTO == null) return NotFound();
            if (transactionDTO.Value < 0) return Content("Value must be greater than zero!");

            try 
            {
                _transactionApplicationService.Withdraw(transactionDTO);
            } 
            catch (Exception exception) 
            {
                return BadRequest(exception.Message);
            }

            return Ok("Transaction Withdraw was a success!");
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