using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Book.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required] public string Title { get; set; }

        public string Description { get; set; }

        [Required] public string ISBN { get; set; }

        [Required] public string Author { get; set; }

        [Required] [Range(1, 10000)] public double Price { get; set; }
        [ValidateNever] public string ImageUrl { get; set; }

        [Display(Name = "Category")]
        [Required] public int CategoryId { get; set; }
        [ValidateNever] public Category Category { get; set; }

        [Display(Name = "Cover Type")]
        [Required] public int CoverTypeId { get; set; }
        [ValidateNever] public CoverType CoverType { get; set; }
    }
}