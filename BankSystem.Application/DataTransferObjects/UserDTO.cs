using System.ComponentModel.DataAnnotations;

namespace BankSystem.Application.DataTransferObjects
{
    public class UserDTO
    {
        [Required]
        public string Name { get; set; }
    }
}