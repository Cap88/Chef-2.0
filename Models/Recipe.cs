using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefInternational.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Label { get; set; }
        [Display(Name = "Ingredient lines")]
        public string IngredientLines { get; set; }
        public string ImageUrl { get; set; }
        public string RecipeUrl { get; set; }
        public string HealthLabels { get; set; }
    }
}