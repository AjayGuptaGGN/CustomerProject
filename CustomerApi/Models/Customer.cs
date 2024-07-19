using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string ProfileImageURL { get; set; }
    }
}
