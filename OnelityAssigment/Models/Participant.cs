using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnelityAssigment.Models
{
    [Table("participants")]
    public class Participant
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is Missing")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Missing")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Missing")]
        [DataType(DataType.EmailAddress)]
        [Email (ErrorMessage = "Is not an e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "conferenceId is Missing")]
        [ForeignKey("conferenceId")]
        public int ConferenceId { get; set; }

        public Conference Conference { get; set; }
    }
}
