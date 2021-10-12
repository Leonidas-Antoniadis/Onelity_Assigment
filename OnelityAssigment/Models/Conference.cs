using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnelityAssigment.Models
{
    [Table("conferences")]
    public class Conference
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
