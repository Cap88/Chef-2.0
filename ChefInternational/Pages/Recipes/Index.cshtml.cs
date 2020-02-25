using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChefInternational.Data;
using ChefInternational.Models;

namespace ChefInternational.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly ChefInternational.Data.ChefInternationalContext _context;

        public IndexModel(ChefInternational.Data.ChefInternationalContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; }

        public async Task OnGetAsync()
        {
            Recipe = await _context.Recipe.ToListAsync();
        }
    }
}
