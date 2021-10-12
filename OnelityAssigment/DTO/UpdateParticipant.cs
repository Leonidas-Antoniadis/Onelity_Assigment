using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace OnelityAssigment.DTO
{
    public class UpdateParticipant
    {
        [Required(ErrorMessage = "Participant Id cant be null or zero")]
        public int Id;
        public string? FirstName {get; set;}

        public string? LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Email(ErrorMessage = "Is not an e-mail")]
        public string? Email { get; set; }

        public int? ConferenceId { get; set; }

    }
}
