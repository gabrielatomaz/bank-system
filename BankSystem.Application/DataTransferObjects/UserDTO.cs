using AutoMapper;

namespace BankSystem.Application.DataTransferObjects
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AccountId { get; set; }
    }
}