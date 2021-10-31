using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolTask.Models
{
    public class Subject
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName ="varchar(250)")]
        [Required(ErrorMessage ="This field is required.")]
        [DisplayName("Name")]
        public string Name { get; set; }
        
        [DisplayName("Code")]
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(7)]
        public string Code { get; set; }
        
        [Column(TypeName ="text")]
        [Required]
        [StringLength(140)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set;}  
        
        [DataType(DataType.Date)]
        public DateTime? UpdatedAt { get; set;}  
    }
}