using System.ComponentModel.DataAnnotations;

namespace Labb3Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        public string? Phone { get; set; }

        public ICollection<PersonalInterest> PersonalInterest { get; set; }
    }
}
