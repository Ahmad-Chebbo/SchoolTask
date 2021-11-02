using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolTask.Models
{
    public class Student
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName ="varchar(250)")]
        [Required(ErrorMessage ="This field is required.")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [DisplayName("University ID")]
        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number")]
        [Range(0, 99999999999, ErrorMessage="University ID must be <= 11 digits")]
        public int UniversityId { get; set; }

        [Required]
        [Range(16, 60, ErrorMessage = "Ages 16-60 only")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number")]
        [DisplayName("Age")]
        public int Age { get; set; }

        [Column(TypeName = "char(1)")]
        [Required]
        [RegularExpression(@"^[MF]+$", ErrorMessage = "Select any one option")]
        [DisplayName("Gender")]
        public char Gender { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set;}  
        
        [DataType(DataType.Date)]
        public DateTime? UpdatedAt { get; set;}
        
        
    }
}