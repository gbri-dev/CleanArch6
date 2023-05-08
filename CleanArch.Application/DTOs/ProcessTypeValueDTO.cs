using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.DTOs
{
     public class ProcessTypeValueDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The Name is Required")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Nome { get; set; }
    }
}
