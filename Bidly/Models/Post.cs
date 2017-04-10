using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bidly.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public Category Category { get; set; }
        [Display(Name = "Category")]
        [Required]
        public byte CategoryId { get; set; }
        public DateTime DateAdded { get; set; }
        [Display(Name = "Till When?")]
        [Required]
        public DateTime Duration { get; set; }

        [Required]
        [Display(Name = "Where?")]
        public string Address { get; set; }
    }
}