using CleanArch.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CleanArch.Application.DTOs
{
    public class IncomeExpenseDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The título is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Título")]
        public string? Title { get;  set; }

        [Required(ErrorMessage = "The closing date is Required")]
        [DisplayName("Closing date")]
        public DateTime ClosingDate { get; set; }

        [Required(ErrorMessage = "The due date is Required")]
        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "The description is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string? Description { get;  set; }

        [Required(ErrorMessage = "The Price is Required")]
        [Column(TypeName ="decimal(18,2)")]        
        [DisplayFormat(DataFormatString ="{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Money { get;  set; }

        [Required(ErrorMessage ="The type is Required")]
        [Range(1, 9999)]
        [DisplayName("Type")]
        public int  TypeValue{ get;  set; }     

        [JsonIgnore]
        public ProcessTypeValue? ProcessType { get; set; }   
    }
}
