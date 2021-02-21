using System.ComponentModel.DataAnnotations;

namespace BankSystem.Application.DataTransferObjects
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}