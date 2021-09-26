using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Contacts{


    public class Contact{

        [Key]
        public int Id { set; get; }
        [Column(TypeName ="nvarchar")]
        [StringLength(50)]
        [Required]
        public string FullName { set; get; }
        [StringLength(50)]
        [Required]
        public string Phone { set; get; }
        [Required]
        [StringLength(100)]
        public string Email { set; get; }
        [Required]
        public string Content { set; get; }
         [Display( Name ="Date")]
        public DateTime DateSent { get; set; }
    }
}