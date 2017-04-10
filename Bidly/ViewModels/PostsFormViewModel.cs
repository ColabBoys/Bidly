using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Bidly.Models;

namespace Bidly.ViewModels
{
    public class PostsFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public int? Id { get; set; }
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


        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Event" : "New Event";
            }
        }

        public PostsFormViewModel()
        {
            Id = 0;
        }

        public PostsFormViewModel(Post posts)
        {
            Id = posts.Id;
            Name = posts.Name;
            Description = posts.Description;
            Address = posts.Address;
            CategoryId = posts.CategoryId;
            DateAdded = posts.DateAdded;
            Duration = posts.Duration;
        }
    }
}