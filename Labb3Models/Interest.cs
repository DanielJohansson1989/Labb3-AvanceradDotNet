using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        [Required]
        [StringLength(20)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public Person Person { get; set; }
    }
}
